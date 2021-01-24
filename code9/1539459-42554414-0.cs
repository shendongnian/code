    private void InsertData(object sender, EventArgs e)
    {
            connectToDatabase()
            car = new Car();
            car.newBrand = txtBrand.Text;
            car.newName = txtName.Text;
            car.newRegisteredYear = txtYear.Text;
            dataBaseConnection.Insert(car);
    }
