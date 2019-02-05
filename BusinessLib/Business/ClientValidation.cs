﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib.Common;
using BusinessLib.Data;

namespace BusinessLib.Business
{
    public class ClientValidation
    {
        private static List<string> errors;
        public static bool success;

        static ClientValidation()
        {
            errors = new List<string>();
        }

        public static string ErrorMessage
        {
            get
            {
                string message = "";

                foreach (string line in errors)
                {
                    message += line + "\r\n";
                }

                return message;
            }
        }

        public static ClientCollection GetAllClients() => ClientRepository.GetAllClients();

        public static int AddClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.AddClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int UpdateClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.UpdateClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int DeleteClient(Client client) => ClientRepository.DeleteClient(client);


        private static bool validate(Client client)
        {
            //     bool success = true;
            success = true;
            errors.Clear();

            if (string.IsNullOrEmpty(client.ClientCode))
            {
                errors.Add("Client Code cannot be empty");
                success = false;
            }


            if (string.IsNullOrEmpty(client.CompanyName))
            {
                errors.Add("Company Name cannot be empty");
                success = false;
            }

            if (string.IsNullOrEmpty(client.Address1))
            {
                errors.Add("Address1 cannot be empty");
                success = false;
            }

            if (string.IsNullOrEmpty(client.Province))
            {
                errors.Add("Province cannot be empty");
                success = false;
            }


            if (client.YTDSales < 0)
            {
                errors.Add("YTDSales cannot be negative");
                success = false;
            }

            if (client.PostalCode?.Length != 7)
            {
                errors.Add("Postal Code length must be 6 ");
                success = false;
            }

            return success;
        }
    }
}
