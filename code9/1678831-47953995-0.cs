    int count = 0;
            if (dtCustomers != null && dtCustomers.Rows.Count > 0)
            {
                dtCustomers.Columns.Add("-Select-");
                foreach (DataRow row in dtCustomers.Rows)
                {
                    Customer obj = new Customer();
                    row["-Select-"] = string.Empty;
