    using Data_Layer.Factory;
    using Domain_Layer.Entity;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace Service_Layer
    {
        public class PeopleService : IPeopleService
        {
            private readonly IEmployeeFactory factory;
    
            private const string getBranches = "...";
            private const string getPeople = "..."
            #region Constructor:
    
            public PeopleService(IEmployeeFactory factory)
            {
                this.factory = factory;
            }
    
            #endregion
    
            public IEnumerable<BranchModel> GetBranches()
            {
                using (var context = factory.Create())
                    return context.List<BranchModel>(getBranches, CommandType.Text);
            }
    
            public IEnumerable<EmployeeModel> GetEmployees(int branchId)
            {
                using (var context = factory.Create())
                    return context.List<EmployeeModel>(getPeople, CommandType.Text, new SqlParameter() { ParameterName = "BranchNum", SqlDbType = SqlDbType.Int, Value = branchId });
            }
        }
    
        #region Declaration of Intent:
    
        public interface IPeopleService
        {
            IEnumerable<BranchModel> GetBranches();
    
            IEnumerable<EmployeeModel> GetEmployees(int branchId);
        }
    
        #endregion
    }
