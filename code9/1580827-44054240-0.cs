				var qry = from i in db.Products
								  select new
								  {
									  Source = i, // <-- this one
									  BusinessOwnerDepartment = i.BusinessOwnerDepartment.Acronym,
									  BusinessOwnerOffice = i.BusinessOwnerOffice.Acronym,
									  SystemOwnerDepartment = i.SystemOwnerDepartment.Acronym,
									  ApplicationType = i.ApplicationType.ToString(),
									  Status = i.IsActive.ToString()
								  };
