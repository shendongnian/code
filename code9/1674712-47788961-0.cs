                foreach (value in values)
                {
                    using (var yourContext = new YourDbContext())
                    {
                        yourContext.Database
                            .ExecuteSqlCommand(
                                "sp_ProcedureName @value1, @value2, @value3",
                                new SqlParameter("@value1", value.value1.ToString()),
                                new SqlParameter("@value2", value.value2.ToString()),
                                new SqlParameter("@value3", value.value3.ToString()));
                    }
                }
