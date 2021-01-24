                String where = string.Empty;
    
                if (search.anno != null)
                    where = " ANNO == " + search.anno ;
    
                if (search.Cliente != null)
                {
                    if (!string.IsNullOrEmpty(where))
                    {
                        where += " And CODICE_CLIENTE == \"" + search.Cliente + "\"";                 }
                    else
                    {
                        where = " CODICE_CLIENTE == \"" + search.Cliente + "\"";
                    }
                }
