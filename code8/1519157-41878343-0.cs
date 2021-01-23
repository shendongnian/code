    public static void FillFilters(MasterPage page) {
        Control parent = page.Controls[0];
        DropDownList[] dropdowns = new DropDownList[3];
        dropdowns[0] = (DropDownList)parent.FindControlRecursive("StatusDropDown");
        dropdowns[1] = (DropDownList)parent.FindControlRecursive("DepartmentDropDown");
        dropdowns[2] = (DropDownList)parent.FindControlRecursive("EmployeeDropDown");
