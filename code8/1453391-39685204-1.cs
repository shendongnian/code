BinaryExpression finalBinaryExpression = null;
 
         switch (_role)
          {
                case GlobalMethods.Roles.L1:
                  finalBinaryExpression =          
                  finalBinaryExpression.CombinedExpression<EmployeeViewModel,int>     
                  (parameterType,"EmpID",homeViewModel.UserViewModel.EmpID);
                 break;
                case GlobalMethods.Roles.L2:
                  finalBinaryExpression =     
                  finalBinaryExpression.CombinedExpression<EmployeeViewModel,int>               
                  (parameterType,"EmpID",homeViewModel.UserViewModel.EmpID)
                  .CombinedExpression<EmployeeViewModel,Roles>                    
              (parameterType,"EmpRole",Enum.GetName(typeof(GlobalMethods.Roles), 0));
                 break;
                case GlobalMethods.Roles.L3:
                    finalBinaryExpression =       
                    finalBinaryExpression.CombinedExpression<EmployeeViewModel,int>
                    (parameterType,"EmpID",homeViewModel.UserViewModel.EmpID)
                    .CombinedExpression<EmployeeViewModel,Roles>
                      
              (parameterType,"EmpRole",Enum.GetName(typeof(GlobalMethods.Roles), 0))
                    .CombinedExpression<EmployeeViewModel,Roles>  
                    
              (parameterType,"EmpRole",Enum.GetName(typeof(GlobalMethods.Roles), 1));
                 break;
            }
