    private void RefreshModules()
    {
        _ds = sdb.GetModules();
        for (int i = 0; i < tempArray.Length; i++)
        {
            DataRow newModuleRow = _ds.Tables["Modules"].NewRow();
            newModuleRow[Address] = "";    //basically set values here
            newModuleRow[ParamValue] = tempArray[i];    //not sure how you will use the Array to add to Modules, that is up to you    
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
