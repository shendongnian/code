    private void getAddressInfo<T>(T party) where T : ICommonInterface {
        //access common  properties
        txtName1.Text = party.Name1;
        //convert to dynamic to call other properties and methods.
        dynamic sharedType = party;
    
        Address addr = sharedType.Addresses.FindPrimary();
        if (addr != null) {
            txtAddr1.Text = addr.Address1;
            txtCity.Text = addr.City;
            txtZip.Text = addr.Zip;
        }
    }
