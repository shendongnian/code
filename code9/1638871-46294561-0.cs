     List<object> VorfahrCK = new List<object>();
     List<object> NachfolgCK = new List<object>();
           
        foreach (object itemChecked1 in clVorfahr.CheckedItems)
        {
             VorfahrCK = clVorfahr.CheckedItems.OfType<object>().ToList();
        }
        foreach (object itemChecked in clNachfolg.CheckedItems)
        {
             NachfolgCK = clNachfolg.CheckedItems.OfType<object>().ToList();
        }
