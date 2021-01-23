     try
               {
                    using (database = new SchoolEmployeesContext())
                    {
                        var data = database.Departments.ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
