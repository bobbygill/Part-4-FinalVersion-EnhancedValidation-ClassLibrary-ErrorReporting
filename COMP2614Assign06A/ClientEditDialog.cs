using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP2614Assign06B
{
    public partial class ClientEditDialog : Form
    {

        public ClientViewModel ClientVM { get; set; }

        public ClientEditDialog()
        {
            InitializeComponent();
        }

        private void ClientEditDialog_Load(object sender, EventArgs e)
        {
            setBindings();
        }

        private void setBindings()
        {
            //       textBoxCompanyName.DataBindings.Add("Text", ClientVM, "CompanyName");
            textBoxCompanyName.DataBindings.Add("Text", ClientVM, "CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress1.DataBindings.Add("Text", ClientVM, "Address1");
            //              textBoxYTDSales.DataBindings.Add("Text", ClientVM, "YTDSales");
            textBoxYTDSales.DataBindings.Add("Text", ClientVM, "YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            checkBoxCreditHold.DataBindings.Add("Checked", ClientVM, "CreditHold");
            textBoxNotes.DataBindings.Add("Text", ClientVM, "Notes");


        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
