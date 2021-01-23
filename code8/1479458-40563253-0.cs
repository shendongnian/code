        var objUserSetUp1 = (from A in userList1
                            join B in userList2 
                                on A.Field<Int64?>("Id") equals B.Field<Int64?>("UserId")
                                into BGroup
                            from C in BGroup.DefaultIfEmpty(userList2.Single(u => u.Field<Int64?>("UserId") == null))
                            select new
                            {
                                UserId = A.Field<Int64>("Id"),
                                FirstName = A.Field<string>("FirstName"),
                                SurName = A.Field<string>("SurName"),
                                Computer_Name = A.Field<string>("Computer_Name"),
                                IP_Address = A.Field<string>("IP_Address"),
                                LogInTime = A.Field<string>("LogInTime") == null
                                                ? "UnKnown"
                                                : A.Field<string>("LogInTime"),
                                UserName = A.Field<string>("UserName"),
                                Password = A.Field<string>("Password"),
                                login_Id = A.Field<Int64?>("login_Id") == null
                                            ? 0 :
                                            A.Field<Int64?>("login_Id"),
                                docCount = C.Field<Int64>("docCount")
                            }).ToList();
