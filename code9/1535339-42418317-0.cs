    public void SubmitButton_Click(object sender, EventArgs args)
    {
        var name = CustomerTextBox.Text
        if (String.IsNullOrWhiteSpace(name)) 
        {
              MessageBox.Show("Enter a customer name!");
              return;
        }
        var result = CreateNewCustomer(name);        
        
        if (result) 
        {
            MessageBox.Show("You have successfully added a customer", "Customer added", MessageBoxButtons.OK);
        } 
        else 
        {
            MessageBox.Show("Something went wrong.", "Customer add failed", MessageBoxButtons.OK);
        }
    }
    private bool CreateNewCustomer(string customerName)
    {
        var result = true;
        
        try 
        {
            var basepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers");
            var custPath = System.IO.Path.Combine(basepath, customerName);
            var appconfigpath = System.IO.Path.Combine(custPath, "app.config");
            if (!System.IO.Directory.Exists(custPath)) 
            {
                System.IO.Directory.CreateDirectory(custPath);
            }
            System.IO.File.Create(appconfigpath);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.TraceError("Error creating customer folder: {0}", ex);
            result = false;
        }    
        return result;
    }
