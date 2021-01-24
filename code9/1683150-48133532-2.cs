        private void BtnView_Click(object sender, EventArgs e)
        {
          DateTime fromDate;
          DateTime toDate;
          int patientNumber; 
 
          if (!DateTime.TryParse(fromdate.Text,fromDate))
          {
              System.Windows.Forms.MessageBox.Show("Invalid From Date");
          }
          else if (!DateTime.TryParse(todate.Text,toDate))
          {
              System.Windows.Forms.MessageBox.Show("Invalid to Date");
          }
          else if (txtPno.Text.Length >= 0 && !Int32.TryParse(txtPno.Text,patientNumber))
          {
              System.Windows.Forms.MessageBox.Show("Invalid Patient Number");
          }
          else
          {
            BL.CLS_PATIENTS view = new BL.CLS_PATIENTS();
            dgvpayments.DataSource = view.GET_PAYMENTS(ToNullableInt(txtPno.Text), fromDate, toDate);
          }
         
        }
