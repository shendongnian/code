    public class ParamPositioningInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (command.CommandText.StartsWith("SELECT") && command.Parameters.Count > 0)
            {
                StringBuilder sb1 = new StringBuilder(command.CommandText);
                StringBuilder sb2 = new StringBuilder();
    
                SqlParameter[] array = new SqlParameter[command.Parameters.Count];
                command.Parameters.CopyTo(array, 0);
    
                foreach (SqlParameter p in array.OrderByDescending(x => x.ParameterName.Length))
                {
                    sb1.Replace("@" + p, "@p" + p);
    
                    switch (p.SqlDbType)
                    {
                        case SqlDbType.Char:
                        case SqlDbType.VarChar:
                        case SqlDbType.NChar:
                        case SqlDbType.NVarChar:
                            sb2.AppendFormat("DECLARE @p{0} {1}({2}) = @{0}", p, p.SqlDbType, p.Size);
                            break;
                        case SqlDbType.Decimal:
                            sb2.AppendFormat("DECLARE @p{0} {1}({2},{3}) = @{0}", p, p.SqlDbType, p.Precision, p.Scale);
                            break;
                        default:
                            sb2.AppendFormat("DECLARE @p{0} {1} = @{0}", p, p.SqlDbType);
                            break;
                    }
    
                    sb2.AppendLine();
                }
    
                command.CommandText = sb2.Append(sb1).ToString();
            }
            //
            base.ReaderExecuting(command, interceptionContext);
        }
    }
