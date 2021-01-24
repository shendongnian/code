    List<Employee> employees = new List<Employee>();
                SqlConnection conn = new SqlConnection("data source=***.***.***.***;initial catalog=***;persist security info=True;user id=***;password=***;MultipleActiveResultSets=True;App=EntityFramework");
                await conn.OpenAsync();
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT (CAST(Availability as int)/CAST(Functionality as int))*100 as Availability from Vu_EquipmentInfo where Vu_EquipmentInfo.MonitoringDate like " + year + "-" + month, conn);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Employee employee = new Employee();
                        employee.Sanctioned_Post = Convert.ToString(reader["Availability"]);
                        employees.Add(employee);
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    await Context.Response.WriteAsync(js.Serialize(employees));
                }
