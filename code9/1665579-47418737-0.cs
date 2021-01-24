    public bool GetDeptData(string StartDate,string EndDate, string deptId, out DataTable DTDepartmentData)
    {
         // The SqlConnection should be created here and destroyed 
         // here, everytime you call this method
         using(SqlConnection con = new SqlConnection(....connectionstring....))
         {
            // then use the deptId value in the creation 
            // of the parameter @DepartmentId
           .....
           cmd.Parameters.Add("@DepartmentID", SqlDbType.VarChar).Value = deptId; 
           adapter.Fill(DTDepartmentData);
           return true;
        }
     }
     catch(Exception ....)
     {
         ...
     }  
