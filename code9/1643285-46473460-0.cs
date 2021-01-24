	private void BindData(object sender, EventArgs e)
	{
		CheckBox box = (CheckBox)sender;
		DataGridItem container = (DataGridItem)box.NamingContainer;
		box.Checked = false;
		//box.Enabled = (readOnly == true) ? false : true;
		//string data = ((DataRowView)container.DataItem)[dataField].ToString();
		//Type t = ((DataRowView)container.DataItem).DataView.Table.Columns[dataField].DataType;
		//if (data.Length > 0)
		//{
		//    switch (t.ToString())
		//    {
		//        case "System.Boolean":
		//            if ((data == "True") || (data == "true"))
		//            {
		//                box.Checked = true;
		//            }
		//            break;
		//        default:
		//            break;
		//    }
		//}
	}
