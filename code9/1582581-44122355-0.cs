    private Add addView;
    private void add(object obj)
        
        if (addView != null)
            addView.Close();
        addView = new Add();
        addView.DataContext = this;
        addView.Show();
    }
    private void ADDFunction(object obj)
    {
        using (Test1Entities context = new Test1Entities())
        {
            context.Custmor.Add(customerToAddObject);
            context.SaveChanges();
            MessageBox.Show("Customer a été ajouté avec succès!");
        }
        _loadDataBinding.Add(CustomerToAddObject);
        if (addView != null)
            addView.Close();
        CustomerToAddObject = new Custmor();
    }
