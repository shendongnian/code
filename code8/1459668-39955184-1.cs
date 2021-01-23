    var dataItem = e.Item as GridEditFormItem;
    if (dataItem != null)
    {
        {
            var comboBox = dataItem.FindControl("myComboId") as RadComboBox;
            if (comboBox != null)
            {
                var value = DataBinder.Eval(dataItem.DataItem, "MyEnumProperty").ToString();
                comboBox.DataSource = Enum.GetValues(typeof(MyEnumProperty));
                comboBox.DataBind();
                var selectedItem = comboBox.FindItemByText(value);
                comboBox.SelectedIndex = selectedItem.Index;
            }
        }
    }
