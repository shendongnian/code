	dt.AsEnumerable().Select(
						row => dt.Columns.Cast<DataColumn>()
					.ToDictionary(
							column => column.ColumnName as string, 
						    column => row["Time"] as object
								 )
							);
