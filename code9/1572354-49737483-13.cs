    using (var conn = new System.Data.SqlClient.SqlConnection(ApplicationConfig.DbConnectInfo.ConnectionString))
    {
    	conn.Open();
    
    	using (var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted))
    	{
    		foreach (var parent in storedProcedures.OrderBy(o => o.Sequence))
    		{
    			var spName = parent.StoredProcedureName;
    
    			var originalValue = parent.OriginalPrimaryKeyValue;
    			var primaryKey = parent.PrimaryKeyUsed;
    
    			parent.Execute(conn, transaction);
    
    			if (parent.Operation == DatabaseOperaion.Insert)
    			{
    				var scopeIdentityValue = (int)parent.SQLParameters[0].Value;
    
    				foreach (DataRelation rel1 in ds.Relations)
    				{
    					var parentColumn = rel1.ParentColumns[0].ToString().ToLower();
    					var childColumn = rel1.ChildColumns[0].ToString().ToLower();
    
    					var childTable = rel1.ChildTable.TableName.ToLower();
    
    					//if (parent.Table == rel1.ParentTable)
    					if (parent.Table.TableName == rel1.ParentTable.TableName)
    					{
    						var children = storedProcedures
    						.Where(w => w.Table.TableName.ToLower() == childTable);
    
    						foreach (var child in children)
    							foreach (var parm in child.SQLParameters)
    								if (parm.ParameterName.Substring(1).ToLower() == childColumn)
    									if ((decimal)parm.Value == originalValue)
    										parm.Value = scopeIdentityValue;
    					}
    
    					var where = string.Format("{0}={1}", primaryKey, originalValue);
    
    					DataRow[] rows = ds.Tables[parent.Table.TableName].Select(where);
    
    					foreach (DataRow row in rows)
    					{
    						row.BeginEdit();
    						row[primaryKey] = scopeIdentityValue;
    						row.EndEdit();
    					}
    				}
    				action = string.Empty;
    			}
    		}
    		transaction.Commit();
    
    		ds.AcceptChanges();
    
    	} // Transaction
    } // SQL Connection
