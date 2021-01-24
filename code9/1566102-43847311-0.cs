    XmlElement employee = xmlDoc.CreateElement("employee");
    xmlDoc.DocumentElement.AppendChild(employee);
    Employees.AppendChild(employee);
    //create the element
    XmlElement NurseId1 = xmlDoc.CreateElement("EmployeeID");
    employee.AppendChild(NurseId1);
        NurseId1.InnerText = row.Cells[0].Text;
    
        XmlElement HireDate1 = xmlDoc.CreateElement("hireDate");
        employee.AppendChild(HireDate1); 
        DateTime newdate = DateTime.ParseExact(row.Cells[6].Text, fromFormat, null); 
    
        HireDate1.InnerText = newdate.ToString(toFormat);//row.Cells[6].Text;
        xmlDoc.DocumentElement.InsertAfter(Employees, xmlDoc.DocumentElement.LastChild);
        
        }
    
        // Create a new <Employees> element and add it to the root node
        XmlElement staffHours = xmlDoc.CreateElement("staffHours");
        xmlDoc.DocumentElement.PrependChild(staffHours);
        parentNode.AppendChild(staffHours);
        // Save to the XML file
        // Create a new <Employees> element and add it to the root node
        XmlElement WorkDays = xmlDoc.CreateElement("childElement");
        xmlDoc.DocumentElement.PrependChild(WorkDays);
        staffHours.AppendChild(WorkDays); 
    
        XmlElement WorkDay = xmlDoc.CreateElement("mainchild");
        xmlDoc.DocumentElement.PrependChild(WorkDay);
         WorkDays.AppendChild(WorkDay);
    
        XmlElement hourEntries = xmlDoc.CreateElement("subchild");
        xmlDoc.DocumentElement.PrependChild(hourEntries);
        WorkDay.AppendChild(hourEntries);
    
        XmlElement HourEntry = xmlDoc.CreateElement("childsub");
        xmlDoc.DocumentElement.PrependChild(HourEntry);
        hourEntries.AppendChild(HourEntry);
       
    //First node and data source
    XmlElement NurseId = xmlDoc.CreateElement("mainelement");
    staffHours.AppendChild(NurseId);
    NurseId.InnerText = row.Cells[0].Text;
    
    //Third node and data source
    XmlElement Date = xmlDoc.CreateElement("date");
    WorkDay.AppendChild(Date);
    DateTime converteddate = DateTime.ParseExact(row.Cells[1].Text, fromFormat, null);
    Date.InnerText = converteddate.ToString(toFormat); 
    
    XmlElement newDept = xmlDoc.CreateElement("childmain");
    //Fourth node and data source
    XmlElement Hours = xmlDoc.CreateElement("hours");
    HourEntry.AppendChild(Hours);
    Hours.InnerText = row.Cells[2].Text;
    
    XmlElement starthour = xmlDoc.CreateElement("starthour");
    HourEntry.AppendChild(starthour);
    starthour.InnerText = row.Cells[9].Text;
    
    XmlElement Lunch = xmlDoc.CreateElement("Lunch");
    HourEntry.AppendChild(Lunch);
    Lunch.InnerText = row.Cells[11].Text;
    
    XmlElement endhour = xmlDoc.CreateElement("endhour");
    HourEntry.AppendChild(endhour);
    endhour.InnerText = row.Cells[10].Text;
    
    XmlElement JobTitleCode = xmlDoc.CreateElement("JobTitleCode");
    HourEntry.AppendChild(JobTitleCode);
    JobTitleCode.InnerText = row.Cells[3].Text;
    
    XmlElement payTypeCode = xmlDoc.CreateElement("payTypeCode");
    HourEntry.AppendChild(payTypeCode);
    payTypeCode.InnerText = row.Cells[4].Text;
    
    xmlDoc.DocumentElement.InsertAfter(parentNode, xmlDoc.DocumentElement.LastChild);
     catid = row.Cells[0].Text;
    }
