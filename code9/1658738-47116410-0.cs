            using (Model1Container obj = new Model1Container())
            {
                return obj.usp_getDepartment().ToList<usp_getDepartment_Result>().Select(m=>new DepartmentModelView{Depid=m.Depid, DepName=m.DepName}).ToList();
            }
        }
