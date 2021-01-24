        private void FormMain_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'quoteDataSet.Quote' table. You can move, or remove it, as needed.
            this.quoteTableAdapter.Fill(this.quoteDataSet.Quote);
            //Start the dialog in Add New Record Mode
            this.quoteBindingNavigator.Items["bindingNavigatorAddNewItem"].PerformClick();
            // Set the Date entered to Today
            dateTimePickerDateEntered.Value = DateTime.Now;
            // Set the call back date to Today + 7 days
            dateTimePickerCallBackDate.Value = DateTime.Now.AddDays(7);
        }
