    private void GetComboValue()
    {
       var value = CMBIDCAT.SelectedItem as DataRowView;
       if (value != null)
       {
           int id = value["ID_CAT"];
           string name = value["CAT_NAME"];          
       }
       //OR if you just need Id
       int id = Convert.ToInt(CMBIDCAT.SelectedValue);
    }
