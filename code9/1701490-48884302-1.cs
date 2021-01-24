	from i in entities.Table1.AsNoTracking().Where(i => (i.IsDeleted == false))
						join se in entities.Table2.AsNoTracking() on i.Id equals se.SId
						join set in entities.Table3.AsNoTracking().Where(i => (i.Name == "Attribute1" && i.Value.Contains("F")))
																				  on i.Id equals set.SId
						join set2 in entities.Table3.AsNoTracking().Where(i => (i.Name == "Atrribute2" && i.Value.Contains("S")))
																				  on i.Id equals set2.SId
						select new
						{
							Name = i.Name,
							Id = i.Id
						};
