        public bool Update_DS(ArrayList strTableName, ArrayList objSqlDataAdapter, ArrayList objDataSet)
        {
            bool ErrorOccured = false;
            try
            {
                _LastException = null;
                objSqlTransaction = objSqlConnection.BeginTransaction();
                for (int i = 0; i < objSqlDataAdapter.Count; i++)
                {
                    SqlDataAdapter objDATemp = (SqlDataAdapter)objSqlDataAdapter[i];
                    //objDATemp.SelectCommand = new SqlCommandBuilder(objDATemp).getse();
                    objDATemp.SelectCommand.Transaction = objSqlTransaction;
                    objDATemp.SelectCommand.Connection = objSqlConnection;
                    objDATemp.UpdateCommand = new SqlCommandBuilder(objDATemp).GetUpdateCommand();
                    objDATemp.UpdateCommand.Transaction = objSqlTransaction;
                    objDATemp.UpdateCommand.Connection = objSqlConnection;
                    objDATemp.InsertCommand = new SqlCommandBuilder(objDATemp).GetInsertCommand();
                    objDATemp.InsertCommand.Transaction = objSqlTransaction;
                    objDATemp.InsertCommand.Connection = objSqlConnection;
                    objDATemp.DeleteCommand = new SqlCommandBuilder(objDATemp).GetDeleteCommand();
                    objDATemp.DeleteCommand.Transaction = objSqlTransaction;
                    objDATemp.DeleteCommand.Connection = objSqlConnection;
                    objDATemp.Update((DataSet)objDataSet[i], strTableName[i].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                _LastException = ex;
                ErrorOccured = true;
                //OnError(ex);
                return false;
            }
            finally
            {
                if (ErrorOccured)
                    objSqlTransaction.Rollback();
                else
                    objSqlTransaction.Commit();
                if (objSqlCommand != null)
                {
                    objSqlCommand.Dispose();
                    objSqlCommand = null;
                }
            }
        }
