     string dateType = DateFieldDropDown.SelectedItem.ToString();
     string DateField1 = DateTextBox.Text;
     string DateField2 = dateSelection2Text.Text;
     string DateFiled = "DateFiled";
     if (dateType == "DateFiled")
     {
       SqlDataSource1.SelectParameters.Add(new Parameter("DateFiled", TypeCode.String, DateFiled));
       SqlDataSource1.SelectParameters.Add(new Parameter("DateField1", TypeCode.String, DateField1));
       SqlDataSource1.SelectParameters.Add(new Parameter("DateField2", TypeCode.String, DateField2));
       SqlDataSource1.SelectCommand = "SELECT * FROM tbl_dateCorrection WHERE DateFiled BETWEEN CAST(@DateField1 AS DATE) AND CAST(@DateField2 AS DATE)";
            SqlDataSource1.DataBind();
            GridView1.DataBind();
