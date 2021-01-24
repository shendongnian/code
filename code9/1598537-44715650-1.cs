    private void RefreshModules()
    {
        _ds = sdb.GetModules();
        for (int i = 0; i < tempArray.Length; i++)
        {
            DataRow newModuleRow = _ds.Tables["Modules"].NewRow();
            newModuleRow[Address] = "your address from other data";
            newModuleRow[ParamValue] = tempArray[i];
            newModuleRow[ParamName] = "your param name";
            ... 
            //use the same syntax to add all the required parameters of a Module structure
  
            _ds.Tables["Modules"].Rows.Add(newModuleRow);
        }
        _ds.Tables["Modules"].DefaultView.Sort = "Address";
        ModulesView = new ListCollectionView(_ds.Tables["Modules"].DefaultView)
        {
            Filter = obj =>
            {
                var Module = obj as DataRowView;
                return SelectedProduct != null && SelectedProduct.ModelNumber == Module["ModelNumber"].ToString();
            }
        };
    }
