     OracleCommand cmd = new OracleCommand("select dname from dept where deptno = :deptno", oc);
                    OracleParameter op = new OracleParameter();
                    op.ParameterName = "deptno";
                    op.OracleDbType = OracleDbType.Int32;
                    op.Direction = System.Data.ParameterDirection.Input;
