    DataTable _dataSourceMatrix = GetManager.Budget.GetAll().ConvertToDataTable();
    DataTable _joinTable = null;
    string _joinField = String.Empty;
    switch (EntityType) {
        case DomainType.Department:
            joinTable = GetManager.DepartmentManager.GetAll().ConvertToDataTable();
            _joinField = "DepartmentID";
            break;
    }
    var _genericBudgetJoinDepartmentList = from a in _dataSourceMatrix.AsEnumerable()
                                           join b in _joinTable.AsEnumerable()
                                           on a.Field<int>("EntityID") equals b.Field<int>(_joinField)
                                           select new { EntityName = b.Field<string>("Name"), Period = a.Field<string>("Period"), Value = a.Field<double>("Value"), EntityID = a.Field<int>("EntityID") };
    _dataSourceMatrix = _genericBudgetJoinDepartmentList.OrderBy(x => x.Period).ConvertToDataTable();
