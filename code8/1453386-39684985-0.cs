            if (!Equals(Role, Enum.GetName(typeof(GlobalMethods.Roles), 3)))
            {
                var _role = (GlobalMethods.Roles)Enum.Parse(typeof(GlobalMethods.Roles), Role, true);
                List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
                string[] viewableRoles = GetViewableRoles(_role);
                employees = context.tblEmployees
                    .Where(x => x.EmpID != homeViewModel.UserViewModel.EmpID)
                    .Where(employee => viewableRoles.Contains(employee.EmpRole))
                    .Select(x => new EmployeeViewModel
                {
                    EmpActive = x.EmpActive,
                    EmpDOB = x.EmpDOB,
                    EmpName = x.EmpName
                }).ToList();
            }
        private string[] GetViewableRoles(GlobalMethods.Roles userRole)
        {
            // Uncomment if L4 can actually view no roles, including itself.
            // /if (userRole == GlobalMethods.Roles.L4)
            // {
            //  return new string[0];
            // }
            IEnumerable<GlobalMethods.Roles> allRoles = Enum.GetValues(typeof(GlobalMethods.Roles)).Cast<GlobalMethods.Roles>();
            return (from role in allRoles 
                    where (int)role >= (int)userRole 
                    select role.ToString()).ToArray();
        }
