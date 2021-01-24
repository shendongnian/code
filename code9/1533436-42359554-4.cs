    static void WhereDemo()
            {
                List<A> aList = new List<A>{
    
                        new A{ Id=1,Name="Hi",Address="Toronto" },
                        new A{ Id=2,Name="Him",Address="NY" },
                        new A{ Id=3,Name="His" },
                        new A{ Id=4,Name="quad",Address="MS" },
                };
    
              var queryOutput=  aList.Where(x => {
                    if (x.Address != null)
                    {
                        x.AddressPresent = "Present";
                        return true; // selects the element
                    }
                    else
                    {
                        x.AddressPresent = "Absent";
                        return false; // does not select the element
                    }
                    
                });
    
                foreach (var element in aList)
                {
    
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", element.Id, element.Name, element.Address, element.AddressPresent);
                }
                Console.WriteLine("-----------------------");
                foreach (var item in queryOutput)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.Id, item.Name, item.Address, item.AddressPresent);
    
                }
            }
