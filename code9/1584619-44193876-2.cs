    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList EquipmentDD = (DropDownList)e.Row.FindControl("dropDownList");
            HiddenField EquipmentCategoryIDHF = (HiddenField) e.Row.FindControl("EquipmentCategoryIDHF");
            HiddenField EquipmentSubCategoryIDHF = (HiddenField) e.Row.FindControl("EquipmentSubCategoryIDHF");
         
            var categoryId = EquipmentCategoryIDHF.Value;
            var subCategoryId = EquipmentSubCategoryIDHF.Value;
            Func<Equipment, bool> criteria;
            if(!string.IsNullOrEmpty(subCategoryId))
            {
                criteria = criteria = equip => equip.CategoryId == categoryId && equip.SubCategoryId == subCategoryId;
            }
            else
            {
                criteria = equip => equip.CategoryId == categoryId;
            }
            var list = equipments.Where(criteria).ToList();
            EquipmentDD.DataSource = list;
            EquipmentDD.DataBind();
            EquipmentDD.Items.Insert(0, new ListItem());
                
        }
    }
