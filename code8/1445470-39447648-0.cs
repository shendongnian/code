    var employeeList2 = list1Obj.GroupJoin(list2Obj, l1 => l1.EmpID, l2 => l2.EmpID, (l1, l2) => new
            {
                l1,
                l2
            }).Select(row => new Employee
            {
                EmpID = row.l1.EmpID,
                EmpName = row.l1.EmpName,
                EmpAddress = row.l2.Select(add => new Address
                {
                    Addr1 = add.Addr1,
                    Addr2 = add.Addr2
                }).ToList()
            });
