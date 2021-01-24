			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new Info { Title = "You api title", Version = "v1" });
				c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme { In = "header",
                      Description = "Please enter into field the word 'Bearer' following by space and JWT", 
                      Name = "Authorization", Type = "apiKey" });
				c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
					{ "Bearer", Enumerable.Empty<string>() },
				});
			});
