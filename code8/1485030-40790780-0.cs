		var result = filledTable.GroupJoin(distinctList, product => product.SerialNumber, row => row.Field<string>("SERIAL NUMBER"), (Product, Rows) => new { Product, Rows })
								.Select(group => new
										{
											Id = group.Product.Id,
											SerialNumber = group.Product.SerialNumber,
											ImportTable = group.Rows.CopyToDataTable()
										});
