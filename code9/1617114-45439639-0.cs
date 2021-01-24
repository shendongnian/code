    //...snip...
    else if (columnField == "StartDate" || columnField == "EndDate")
    {
    	string date = Erp.Core.Utils.GetStringFromObject(valueObject);
        //parsing date string
    	DateTime columnDate = DateTime.ParseExact(date, "yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
       
    	eventRow[columnField] = columnDate;
    }
    else if (columnField != "PartnerId" && columnField != "StartDate" && columnField != "EndDate")
    {
    	eventRow[columnField] = valueObject;
    }
