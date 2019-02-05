using BusinessLib.Business;
using BusinessLib.Common;
using BusinessLib.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP2614Assign06B
{
    public partial class MainForm : Form
    {
        private ClientViewModel clientVM;
        private bool confirmDelete;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            clientVM = new ClientViewModel(ClientValidation.GetAllClients());  // so there is no direct acces to the data
            setBindings();
            setupDataGridView();
            resetDisplay();


        }

        public void resetDisplay()
        {
            labelTotalYTDSalesDisplay.Text = clientVM.Clients.TotalYTDSales.ToString();
            labelCreditHoldCountDisplay.Text = clientVM.Clients.CreditHoldCount.ToString();
            int recordCount = clientVM.Clients.Count;
            labelRecordCountDisplay.Text = recordCount.ToString();
        }

        private void setBindings()
        {
            dataGridViewClients.AutoGenerateColumns = false;
            dataGridViewClients.DataSource = clientVM.Clients;

        }

        private void setupDataGridView()
        {
            // configure for readonly 

            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.MultiSelect = false;
            dataGridViewClients.AllowUserToAddRows = false;
            dataGridViewClients.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewClients.AllowUserToOrderColumns = false;
            dataGridViewClients.AllowUserToResizeColumns = false;
            dataGridViewClients.AllowUserToResizeRows = false;
            dataGridViewClients.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            //// add columns

            DataGridViewTextBoxColumn clientCode = new DataGridViewTextBoxColumn();
            clientCode.Name = "clientCode";
            clientCode.DataPropertyName = "ClientCode"; //has to match the Property Method name exactly
            clientCode.HeaderText = "Client Code";
            clientCode.Width = 70;
            clientCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            clientCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clientCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(clientCode);

            DataGridViewTextBoxColumn companyName = new DataGridViewTextBoxColumn();
            companyName.Name = "companyName";
            companyName.DataPropertyName = "CompanyName";
            companyName.HeaderText = "Company Name";
            companyName.Width = 160;
            companyName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            companyName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            companyName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(companyName);

            DataGridViewTextBoxColumn address1 = new DataGridViewTextBoxColumn();
            address1.Name = "address1";
            address1.DataPropertyName = "Address1";
            address1.HeaderText = "Address";
            address1.Width = 140;
            address1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            address1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            address1.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(address1);

            //no need to display address 2 on the main form
            //DataGridViewTextBoxColumn address2 = new DataGridViewTextBoxColumn();
            //address2.Name = "address2";
            //address2.DataPropertyName = "Address2";
            //address2.HeaderText = "Address2";
            //address2.Width = 160;
            //address2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //address2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //address2.SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridViewClients.Columns.Add(address2);

            DataGridViewTextBoxColumn city = new DataGridViewTextBoxColumn();
            city.Name = "city";
            city.DataPropertyName = "City";
            city.HeaderText = "City";
            city.Width = 80;
            city.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            city.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            city.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(city);

            DataGridViewTextBoxColumn postalCode = new DataGridViewTextBoxColumn();
            postalCode.Name = "postalCode";
            postalCode.DataPropertyName = "PostalCode";
            postalCode.HeaderText = "Postal Code";
            postalCode.Width = 60;
            postalCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            postalCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            postalCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(postalCode);

            DataGridViewTextBoxColumn ytdsales = new DataGridViewTextBoxColumn();
            ytdsales.Name = "ytdsales";
            ytdsales.DataPropertyName = "YTDSales";
            ytdsales.HeaderText = "YTDSales";
            ytdsales.Width = 70;
            ytdsales.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ytdsales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ytdsales.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(ytdsales);

            DataGridViewTextBoxColumn notes = new DataGridViewTextBoxColumn();
            notes.Name = "notes";
            notes.DataPropertyName = "Notes";
            notes.HeaderText = "Notes";
            notes.Width = 116;
            notes.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            notes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            notes.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(notes);

            DataGridViewCheckBoxColumn creditHold = new DataGridViewCheckBoxColumn();
            creditHold.Name = "creditHold";
            creditHold.DataPropertyName = "CreditHold";
            creditHold.HeaderText = "Credit Hold";
            creditHold.Width = 50;
            //       creditHold.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //      creditHold.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //looks better without the middle alightment
            creditHold.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(creditHold);


        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = dataGridViewClients.CurrentRow.Index;
            clientVM.SetDisplayClient(clientVM.Clients[index]);
            ClientEditDialog dialog = new ClientEditDialog();
            dialog.isEditMode = true;

            dialog.ClientVM = clientVM;

            string errorMessage;

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                clientVM.Clients = ClientValidation.GetAllClients();
                dataGridViewClients.DataSource = clientVM.Clients;
            }


            if (ClientEditDialog.rowsAffected == 0)
            {
                errorMessage = "No DB changes were made";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dialog.Dispose();
            resetDisplay();
            dialog.isEditMode = false;
        }

        //my code is repeating here... 
        private void buttonNewRecord_Click(object sender, EventArgs e)
        {
            int index = dataGridViewClients.CurrentRow.Index;
            string errorMessage;
            clientVM.SetDisplayClient(new Client());
            ClientEditDialog dialog = new ClientEditDialog();
            dialog.ClientVM = clientVM;

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                clientVM.Clients = ClientValidation.GetAllClients();
                dataGridViewClients.DataSource = clientVM.Clients;
            }

            if (ClientEditDialog.rowsAffected == 0)
            {
                errorMessage = "No DB changes were made";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dialog.Dispose();
            resetDisplay();
        }

        public bool confirm()
        {
            DialogResult result = MessageBox.Show("Delete Record?",          // Message Text
                                                 "Confirm Delete",          // Caption Text
                                                 MessageBoxButtons.YesNo,   // Buttons
                                                 MessageBoxIcon.Question);  // Icon

            if (result == DialogResult.Yes)
            {
                return true;
            }

            else
            {
                return false;
            }


        }

        public void delete()
        {
            try
            {
                int index = dataGridViewClients.CurrentRow.Index;
                clientVM.SetDisplayClient(clientVM.Clients[index]);
                Client client = clientVM.GetDisplayClient();

                ClientValidation.DeleteClient(client);
                clientVM.Clients = ClientValidation.GetAllClients();
                dataGridViewClients.DataSource = clientVM.Clients;
                resetDisplay();
            }


            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if (checkBoxConfirmDeletion.Checked)
            {
                confirmDelete = confirm();
                if (confirmDelete)
                {
                    delete();
                }
            }
            else if (!checkBoxConfirmDeletion.Checked)
            {
                delete();
            }

        }
    }

}
