     SqlHelper<Employee> hlp = new SqlHelper<Employee>(new SqlConnection
                (new SqlConnectionStringBuilder
                {
                    DataSource = @"(local)\SQLEXPRESS",
                    InitialCatalog = "SomeDatabase",
                    IntegratedSecurity = true
                }.ToString()));
            Employee e = new Employee { FirstProp = 3, SecondProp = "SomeText3" };
            List<Employee> list = hlp.ReturnSelect();
            bool Insertresult= hlp.InsertInto(e);
            bool Updateresult=hlp.Update(e);
            bool Deleteresult=hlp.Delete(e);
