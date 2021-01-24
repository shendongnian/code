        //Commands methods
        public void SaveAddBank()
        {
            new Banks().AddBank(this.BankName, _Status, System.Convert.ToDouble(Credit), this.Notes);
            new Done("Bank has been added successfully.");
            //here i want to close the window.
            CloseWindowEvent?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler CloseWindowEvent;
