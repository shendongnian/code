    using (DataTable cTable = _SQLConnection.GetData("SELECT Name FROM Carrier")){
        foreach (2ndClassname class1 in 2ndClassName.allData){
        ComboBox.Items.Add(class1.COLUMNNAME);//I am unaware of how many columns your database has :/
        }
    }
