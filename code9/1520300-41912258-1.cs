    foreach (DataRow DR in Dtable.Rows)
    {
        DateTime dt = Convert.ToDateTime(DR["VisitDate"]);
        PersianDateLibrary.PerCalander Per = new PersianDateLibrary.PerCalander();
        DateTime ct = Convert.ToDateTime(Per.
        GetPersianDate(dt, PersianDateLibrary.PerCalander.DateFormat.Short));
        DR["VisitDate"] = ct;
    }
