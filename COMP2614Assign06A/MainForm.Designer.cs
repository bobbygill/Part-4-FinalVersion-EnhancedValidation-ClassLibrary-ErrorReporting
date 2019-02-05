namespace COMP2614Assign06B
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonNewRecord = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelTotalYTDSales = new System.Windows.Forms.Label();
            this.labelTotalYTDSalesDisplay = new System.Windows.Forms.Label();
            this.labelCreditHoldCount = new System.Windows.Forms.Label();
            this.labelCreditHoldCountDisplay = new System.Windows.Forms.Label();
            this.labelRecordCount = new System.Windows.Forms.Label();
            this.labelRecordCountDisplay = new System.Windows.Forms.Label();
            this.checkBoxConfirmDeletion = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(28, 26);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(790, 248);
            this.dataGridViewClients.TabIndex = 4;
            this.dataGridViewClients.DoubleClick += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(743, 289);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "&Edit Record";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonNewRecord
            // 
            this.buttonNewRecord.Location = new System.Drawing.Point(648, 289);
            this.buttonNewRecord.Name = "buttonNewRecord";
            this.buttonNewRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonNewRecord.TabIndex = 1;
            this.buttonNewRecord.Text = "&New Record";
            this.buttonNewRecord.UseVisualStyleBackColor = true;
            this.buttonNewRecord.Click += new System.EventHandler(this.buttonNewRecord_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(545, 289);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelTotalYTDSales
            // 
            this.labelTotalYTDSales.AutoSize = true;
            this.labelTotalYTDSales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalYTDSales.Location = new System.Drawing.Point(42, 294);
            this.labelTotalYTDSales.Name = "labelTotalYTDSales";
            this.labelTotalYTDSales.Size = new System.Drawing.Size(93, 14);
            this.labelTotalYTDSales.TabIndex = 5;
            this.labelTotalYTDSales.Text = "Total YTD Sales:";
            // 
            // labelTotalYTDSalesDisplay
            // 
            this.labelTotalYTDSalesDisplay.AutoSize = true;
            this.labelTotalYTDSalesDisplay.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalYTDSalesDisplay.Location = new System.Drawing.Point(141, 294);
            this.labelTotalYTDSalesDisplay.Name = "labelTotalYTDSalesDisplay";
            this.labelTotalYTDSalesDisplay.Size = new System.Drawing.Size(61, 14);
            this.labelTotalYTDSalesDisplay.TabIndex = 6;
            this.labelTotalYTDSalesDisplay.Text = "<Amount>";
            // 
            // labelCreditHoldCount
            // 
            this.labelCreditHoldCount.AutoSize = true;
            this.labelCreditHoldCount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreditHoldCount.Location = new System.Drawing.Point(208, 294);
            this.labelCreditHoldCount.Name = "labelCreditHoldCount";
            this.labelCreditHoldCount.Size = new System.Drawing.Size(105, 14);
            this.labelCreditHoldCount.TabIndex = 7;
            this.labelCreditHoldCount.Text = "Credit Hold Count:";
            // 
            // labelCreditHoldCountDisplay
            // 
            this.labelCreditHoldCountDisplay.AutoSize = true;
            this.labelCreditHoldCountDisplay.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreditHoldCountDisplay.Location = new System.Drawing.Point(319, 294);
            this.labelCreditHoldCountDisplay.Name = "labelCreditHoldCountDisplay";
            this.labelCreditHoldCountDisplay.Size = new System.Drawing.Size(50, 14);
            this.labelCreditHoldCountDisplay.TabIndex = 8;
            this.labelCreditHoldCountDisplay.Text = "<Count>";
            // 
            // labelRecordCount
            // 
            this.labelRecordCount.AutoSize = true;
            this.labelRecordCount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordCount.Location = new System.Drawing.Point(375, 294);
            this.labelRecordCount.Name = "labelRecordCount";
            this.labelRecordCount.Size = new System.Drawing.Size(81, 14);
            this.labelRecordCount.TabIndex = 9;
            this.labelRecordCount.Text = "Record Count:";
            // 
            // labelRecordCountDisplay
            // 
            this.labelRecordCountDisplay.AutoSize = true;
            this.labelRecordCountDisplay.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordCountDisplay.Location = new System.Drawing.Point(462, 294);
            this.labelRecordCountDisplay.Name = "labelRecordCountDisplay";
            this.labelRecordCountDisplay.Size = new System.Drawing.Size(62, 14);
            this.labelRecordCountDisplay.TabIndex = 10;
            this.labelRecordCountDisplay.Text = "<Records>";
            // 
            // checkBoxConfirmDeletion
            // 
            this.checkBoxConfirmDeletion.AutoSize = true;
            this.checkBoxConfirmDeletion.Location = new System.Drawing.Point(545, 318);
            this.checkBoxConfirmDeletion.Name = "checkBoxConfirmDeletion";
            this.checkBoxConfirmDeletion.Size = new System.Drawing.Size(103, 17);
            this.checkBoxConfirmDeletion.TabIndex = 3;
            this.checkBoxConfirmDeletion.Text = "C&onfirm Deletion";
            this.checkBoxConfirmDeletion.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 343);
            this.Controls.Add(this.checkBoxConfirmDeletion);
            this.Controls.Add(this.labelRecordCountDisplay);
            this.Controls.Add(this.labelRecordCount);
            this.Controls.Add(this.labelCreditHoldCountDisplay);
            this.Controls.Add(this.labelCreditHoldCount);
            this.Controls.Add(this.labelTotalYTDSalesDisplay);
            this.Controls.Add(this.labelTotalYTDSales);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonNewRecord);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.dataGridViewClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMP2614 A00913705 Assign06";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonNewRecord;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelTotalYTDSales;
        private System.Windows.Forms.Label labelTotalYTDSalesDisplay;
        private System.Windows.Forms.Label labelCreditHoldCount;
        private System.Windows.Forms.Label labelCreditHoldCountDisplay;
        private System.Windows.Forms.Label labelRecordCount;
        private System.Windows.Forms.Label labelRecordCountDisplay;
        private System.Windows.Forms.CheckBox checkBoxConfirmDeletion;
    }
}

