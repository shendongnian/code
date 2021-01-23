    var xmlStr = File.ReadAllText(Server.MapPath("YourFileName.xml"));
                    var str = XElement.Parse(xmlStr);
                    var result = str.Elements("SkillSets").Where(x => x.Element("EmployeeID").Value.Equals(emplid.ToString())).ToList();
        
                    List<Employee> mapList = new List<Employee>();
        
                    foreach (var item in result)
                    {
                        Employee obj = new Employee();
                        obj.EmployeeID = item.Element("EmployeeID").Value;
                        obj.EmployeeName = item.Element("EmployeeName").Value;
                        obj.PLName = item.Element("PLName").Value;
                        obj.SkillName1 = item.Element("SkillName1").Value;
                        obj.SkillType1 = item.Element("SkillType1").Value;
                        obj.SkillProficiency1 = item.Element("SkillProficiency1").Value;
                        obj.Experience1 = item.Element("Experience1").Value;
                        obj.Comments = item.Element("Comments").Value;
                        mapList.Add(obj);
                    }
        
                    grdxml.DataSource = mapList;
                    grdxml.DataBind();  
