using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace COMP2614Assign06B
{
    class ClientRepository
    {

        private static string connString = @"Server = tcp:skeena.database.windows.net,1433;
                                            Initial Catalog = comp2614;
                                            User ID = student;
                                            Password=93nu5#Z183;
                                            Encrypt = True;
                                            TrustServerCertificate=False;
                                            Connection Timeout = 30;";

        public static ClientCollection GetAllClients()
        {
            ClientCollection clients;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query;

          
                query = @"SELECT ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes
                               FROM Client
                               ORDER BY CompanyName; ";
         


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    clients = new ClientCollection();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string clientCode; // not null 0
                        string companyName; // not null 1
                        string address1; // not null 2
                        string address2 = null; //null 3
                        string city = null; //null 4
                        string province; // not null 5
                        string postalCode = null; //null 6
                        decimal ytdSales; //not null 7 
                        bool creditHold; //not null 
                        string notes = null; //null 9

                        while (reader.Read())
                        {
                            clientCode = reader["ClientCode"] as string; // 0
                            companyName = reader["CompanyName"] as string; // 1
                            address1 = reader["Address1"] as string; // 2


                            if (!reader.IsDBNull(3))
                            {
                                address2 = reader["Address2"] as string;
                            }
                            if (!reader.IsDBNull(4))
                            {
                                city = reader["City"] as string;
                            }

                            province = reader["Province"] as string; //5 


                            if (!reader.IsDBNull(6))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }

                            ytdSales = (decimal)reader["YTDSales"]; //7

                            creditHold = (bool)reader["CreditHold"]; //8

                            if (!reader.IsDBNull(9))
                            {
                                notes = reader["Notes"] as string;
                            }


                            clients.Add(new Client(clientCode, companyName, address1, address2, city, province, postalCode, ytdSales, creditHold, notes));

                            clientCode = null;
                            companyName = null;
                            address1 = null;
                            province = null;
                            ytdSales = 0;
                            creditHold = false;
                        }
                    }

                    return clients;

                }
            }
        }
    }
}
