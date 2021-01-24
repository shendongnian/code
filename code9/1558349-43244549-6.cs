        public void SaveChanges()
        {
            var isValid = validateFirstName()
                       && validateLastName()
                       && validateJobCode()
                       && validateStoreCode();
            if (isValid)
            {
                this.eMPLOYEEBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.empDataSet);
            }
        }
        private bool validateFirstName()
        {
            var isValidFirstName = !string.IsNullOrEmpty(txtName.Text);
            if (!isValidFirstName)
            {
                MessageBox.Show("Fill in First Name", "Missing Data");
                txtName.Focus();
            }
            return isValidFirstName;
        }
        private bool validateLastName()
        {
            var isValidLastName = !string.IsNullOrEmpty(txtLastname.Text);
            if (!isValidLastName)
            {
                MessageBox.Show("Fill in Last Name", "Missing Data");
                txtLastname.Focus();
            }
            return isValidLastName;
        }
        private bool validateJobCode()
        {
            var isValidJobeCode = txtJobCode.Text == "SEC"
                               || txtJobCode.Text == "MGR"
                               || txtJobCode.Text == "GEN";
            if (!isValidJobeCode)
            {
                MessageBox.Show("Fill in Job Code with SEC, MGR or GEN", "Missing Data");
                txtJobCode.Focus();
            }
            return isValidJobeCode;
        }
        private bool validateStoreCode()
        {
            var storeCode = 0;
            var isValidStoreCode = int.TryParse(txtStoreCode.Text, out storeCode)
                                   && storeCode >= 1 
                                   && storeCode <= 5;
            if (!isValidStoreCode)
            {
                MessageBox.Show("Fill in Store Code 1-5", "Missing Data");
                txtStoreCode.Focus();
            }
            return isValidStoreCode;
        }
    }
