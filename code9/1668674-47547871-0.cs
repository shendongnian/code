    allEmployeeProject = v.Skip(skip).Take(pageSize).Where(y => y.Epmm.IsActive && !y.Epmm.IsDelete && y.Eptm.IsActive && !y.Eptm.IsDelete).Select(x => new EmployeeProjectMasterModelClient
            {
                EmployeeProjectMasterId = x.Epmm.EmployeeProjectMasterId,
                ProjectId = x.Epmm.ProjectId,
                ProjectName = x.Epmm.ProjectModel.ProjectName,
                WorkDateS = SqlFunctions.DateName("day", x.Epmm.WorkDate) + "/ " + SqlFunctions.DateName("month", x.Epmm.WorkDate) + "/ " + SqlFunctions.DateName("year", x.Epmm.WorkDate),
                SalaryForEachEmployee = x.Epmm.SalaryForEachEmployee,
                EmployeeProjectTransactionModel = *************************************How to Load Trnsaction Details As A list Here
            });
    var allEmployeeProjectsByMaster = allEmployeeProject.GroupBy(x => x.EmployeeProjectMasterId).ToList();
