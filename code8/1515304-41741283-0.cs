    DbContext.Entry(entity).State = EntityState.Modified;
				foreach (var service in entity.Service)
				{
					DbContext.Entry(service).State = EntityState.Modified;
					foreach (var position in service.Positions)
					{
						DbContext.Entry(position).State = EntityState.Modified;
						if (position.OrganizationUnit == null) continue;
						foreach (var organizationUnit in position.OrganizationUnit)
						{
							DbContext.Entry(organizationUnit).State = EntityState.Modified;
						}
					}
				}
				DbContext.SaveChanges();
