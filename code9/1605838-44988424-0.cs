    using (MyEntities myEntities = new MyEntities())
                {
                    List<EMPLOYEELookUpData> employeeLookupData;
                    try
                    {
                        employeeLookupData = myDB
                            .Employee
                            .Select<EMPLOYEELookUpData >
                            .Where(c => x => x.ACTIVE == 1)
                            .ToList();
                    }
                    catch (InvalidOperationException e)
                    {
                        //Write a log entry
                    }
