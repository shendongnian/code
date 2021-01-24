        if (search.anno != null)
            where = " ANNO = @0 ";
          parameters = new object[] { search.anno };
        if (search.Cliente != null)
        {
            if (!string.IsNullOrEmpty(where))
            {
                where += " && CODICE_CLIENTE = @1";
                parameters = new object[] { search.anno, search.Cliente };
            }
            else
            {
                where = " CODICE_CLIENTE = @0";
                parameters = new object[] { search.Cliente };
            }
        }
        if (search.linea != null)
        {
            if (!string.IsNullOrEmpty(where))
            {
                where += " && LINEA.Contains(@2) ";
                parameters = new object[] { search.anno, search.Cliente, search.linea };
            }
            else
            {
                where = " LINEA.Contains(@0) ";
                parameters = new object[] { search.linea };
            }
        }
