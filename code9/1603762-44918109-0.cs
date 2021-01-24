    public List<T> ExecuteStoredProc(string StoredProcName, List<SqlParameter> parameters)
        {
            List<T> list = null;
            try
            {
                if (!string.IsNullOrEmpty(StoredProcName))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Exec ");
                    sb.Append(StoredProcName);
                    foreach (SqlParameter item in parameters)
                    {
                        if (list == null)
                        {
                            sb.Append(" @");
                            list = new List<T>();
                        }
                        else
                        {
                            sb.Append(", @");
                        }
                        sb.Append(item.ParameterName);
                        if (item.Direction == System.Data.ParameterDirection.Output)
                        {
                            sb.Append(" OUT");
                        }
                    }
                    list = Context.Database.SqlQuery<T>(sb.ToString(), parameters.Cast<object>().ToArray()).ToList();
                }
            }
            catch (SqlException ex)
            {
                //RAISERROR() has limitation of 255 characters, so complete error message is being passed through output parameter : @ErrorMessage
                if (parameters != null && parameters.Count > 0)
                {
                    SqlParameter param = parameters.FirstOrDefault(a => a.Direction == ParameterDirection.Output && a.ParameterName == Constants.Constant.ParamErrorMessage);
                    if (param != null)
                    {
                        string errorMessage = Convert.ToString(param.Value);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            throw new JcomSqlException(errorMessage, ex);
                        }
                    }
                }
                throw new JcomSqlException(ex.Message, ex);
            }
            return list;
        }
        Then use it with your repository 
           List<GetDepartmentDetails_Result> getDepts(string deptName)
        {
            List<SqlParameter> spm = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName="@DepartmentName", Value=deptName}
            };
            var result = this.UnitOfWork.GetRepository<GetDepartmentDetails_Result>().ExecuteStoredProc("GetDepartmentDetails", spm);
            return result;
        }
