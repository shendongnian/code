    DateTime dt1;
    DateTime dt2;
    if (DateTime.TryParse(strDate1, out dt1) && DateTime.TryParse(strDate2, out dt2))
     {
        if (dt1.Date == dt2.Date)
        {
           // the dates are identical
        }
    }
