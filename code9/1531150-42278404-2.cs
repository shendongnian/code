    private void privatecustomer_Click(object sender, RoutedEventArgs e)
    {
      var privateCustomerContent=new Privatecustomer.privatecustomer_show();
      privateCustomerContent.AddPrivateCustomer+=onClick_addPrivateCustomer;
      Main.Content = privateCustomerContent;
    }
    private onClick_addPrivateCustomer(object o,EventArgs e)
    {
      // Change Main.Content
    }
