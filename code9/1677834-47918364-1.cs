    class PersonalAccounts : Account , IPayMyBill
    {
        ...
        public void Pay()
        {
            // This will work because child classes can access protected members from their base class and _amountDue was declared above as protected
            _amountDue = 0;
        }
        public void ChangeAddress(string newAddress)
        {
            // This won't work because _address is private so can't be accessed by the child class
            _address = newAddress;
        }
    }
