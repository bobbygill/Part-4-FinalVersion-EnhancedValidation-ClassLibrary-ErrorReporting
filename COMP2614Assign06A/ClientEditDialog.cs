using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLib.Business;
using BusinessLib.Common;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace COMP2614Assign06B
{
    public partial class ClientEditDialog : Form
    {

        public ClientViewModel ClientVM { get; set; }
        public bool isEditMode { get; set; }
        public static int rowsAffected;
        private string errorMessage;
        public static List<string> provinces;

        public ClientEditDialog()
        {
            InitializeComponent();
        //    GetAllProvinces();
        }

        private void ClientEditDialog_Load(object sender, EventArgs e)
        {
            setBindings();
      //      testProvinces2();
        }

        public static string TestProvinces
        {
            get
            {
                string province = "";

                foreach (string p in provinces)
                {
                    province += p + "\r\n";
                }

                return province;
            }
        }

        public void testProvinces2()
        {
            MessageBox.Show(TestProvinces, "Province List", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void setBindings()
        {
            if (isEditMode)
            {
                maskedTextBoxClientCode.ReadOnly = true;
            }

            maskedTextBoxClientCode.DataBindings.Add("Text", ClientVM, "ClientCode");
            textBoxCompanyName.DataBindings.Add("Text", ClientVM, "CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress1.DataBindings.Add("Text", ClientVM, "Address1");
            textBoxAddress2.DataBindings.Add("Text", ClientVM, "Address2");
            textBoxCity.DataBindings.Add("Text", ClientVM, "City");
            maskedTextBoxProvince.DataBindings.Add("Text", ClientVM, "Province");
            maskedTextBoxPostalCode.DataBindings.Add("Text", ClientVM, "PostalCode");
            //              textBoxYTDSales.DataBindings.Add("Text", ClientVM, "YTDSales");
            textBoxYTDSales.DataBindings.Add("Text", ClientVM, "YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            checkBoxCreditHold.DataBindings.Add("Checked", ClientVM, "CreditHold");
            textBoxNotes.DataBindings.Add("Text", ClientVM, "Notes");


        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(buttonOK, string.Empty);


            Client client = ClientVM.GetDisplayClient();
            if (isEditMode)
            {
                rowsAffected = ClientValidation.UpdateClient(client);
            }
            else
            {
                rowsAffected = ClientValidation.AddClient(client);
            }




            string regExClientCode = @"^[A-Z][A-Z][A-Z][A-Z][A-Z]$";
            string regExProvince = @"^[A-Z][A-Z]$";
            string regExCdnPostalCode = @"^[A-Z]\d[A-Z] \d[A-Z]\d$";

            if (!Regex.IsMatch(maskedTextBoxClientCode.Text, regExClientCode))
            {
                // errorProvider.SetError(buttonOK, "Client Code must be 5 characters, Ex: AAAAA");
                errorMessage += "Client Code must be 5 characters, Ex: AAAAA\n";
            }

            if (!Regex.IsMatch(maskedTextBoxProvince.Text, regExProvince))
            {
                //   errorProvider.SetError(buttonOK, "Province must be 2 characters, Ex: BC");
                errorMessage += "Province must be 2 characters, Ex: BC\n";
            }

            if (!Regex.IsMatch(maskedTextBoxPostalCode.Text, regExCdnPostalCode))
            {
                //   errorProvider.SetError(buttonOK, "Postal Code Format is Incorrect, Ex: V3G 1X5");
                errorMessage += "Postal Code Format is Incorrect, Ex: V3G 1X5\n";
            }

            if (rowsAffected < 0) // if there was an error in validation
            {
                errorMessage += ClientValidation.ErrorMessage;
                errorProvider.SetIconAlignment(buttonOK, ErrorIconAlignment.MiddleLeft);
                errorProvider.SetError(buttonOK, errorMessage);
                errorMessage = "";
            }



            else
            {
                this.DialogResult = DialogResult.OK;
            }


        }


        //probably shouldn't be doing this here...
        //I think I will skip the optional part, can't figure out how to get the selected drop down item to bind
        // deleted combo box component and selected index method

        private static string connString = @"Server = tcp:skeena.database.windows.net,1433;
                                            Initial Catalog = comp2614;
                                            User ID = student;
                                            Password=93nu5#Z183;
                                            Encrypt = True;
                                            TrustServerCertificate=False;
                                            Connection Timeout = 30;";

        public static List<string> GetAllProvinces()
        {


            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query;


                query = @"SELECT ProvinceId, Abbreviation, Name
                               FROM Province
                               ORDER BY Name";


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    provinces = new List<string>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string provinceId; // not null 0
                        string abbreviation; // not null 1
                        string name = null; //null 2


                        while (reader.Read())
                        {
                            provinceId = reader["ProvinceId"] as string; // 0
                            abbreviation = reader["Abbreviation"] as string; // 1


                            if (!reader.IsDBNull(2))
                            {
                                name = reader["Name"] as string;
                            }

                            //       provinces.Add(provinceId);
                            provinces.Add(abbreviation);
                            //       provinces.Add(name);
                        }
                    }

                    return provinces;

                }
            }



        }

     
    }
}
