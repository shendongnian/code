    namespace MvcApplication4.Models
    {
        public partial class usp_getDepartment_Result
        {
            static public implicit operator DepartmentModelView(usp_getDepartment_Result input)
            {
                return new DepartmentModelView
                {
                    Depid = input.Depid,
                    DepName = input.DepName
                };
            }
        }
    }
