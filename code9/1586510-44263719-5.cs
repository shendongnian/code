    var selectedIds = chklstDepartment.Items.Cast<ListItem>()
                                            .Where(item => item.Selected)
                                            .Select(item => Convert.ToInt32(item.Value))
                                            .ToArray(); // or ToList() or HashSet
    .Where(i => (chklstDepartment.SelectedValue == "0")
             || (selectedIds.Contains(i._Department.DepartmentID)))
