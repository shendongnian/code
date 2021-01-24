	var projection = from location in locations
					 group location by location.Geography into geographies
					 select new
					 {
					 	Geography = geographies.Key,
						Countries = from geography in geographies
									group geography by geography.Country into countries
									select new
									{
										Country = countries.Key,
										States = from country in countries
												group country by country.State into states
												select new
												{
													State = states.Key,
													Offices = from state in states
															select new
															{
																Id = state.Id,
																Office = state.Office,
															}
												 }
									}
					};
