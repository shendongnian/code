    public ActionResult ViewModules(int id)
            {
                Domain_Bind();
                dynamic mymodel = new ExpandoObject();
                userType type = new userType();
    
    
                List<ViewRoleModules> EmpList = type.GetRoleModulesViews(id);
    
                List<ViewRoleModules> RoleList;
                List<ViewRoleModules> test = new List<ViewRoleModules>();
                foreach (ViewRoleModules emp in EmpList)
                {
                    RoleList = type.GetSiteRoleModulesViews(emp.ModuleId);
                    foreach (ViewRoleModules vip in RoleList)
                    {
                        test.Add(new ViewRoleModules
                        {
                            RoleName = vip.RoleName,
                            ModuleId = vip.ModuleId
                        });
                    }
                }
    
                var data = new { EmpList = EmpList, test = test };
    
                return Json(data, JsonRequestBehavior.AllowGet);
    
            }
