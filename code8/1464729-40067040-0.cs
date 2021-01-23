            // read file : Groceries.txt
            string[] groceries = File.ReadAllLines("Groceries.txt");
            // process groceries input
            List<string> invoices = new List<string>();
            foreach(var grocery in groceries)
            {
                invoices.Add(grocery + "," + DateTime.Now.Date);
            }
            // write file :  Invoices.txt
            File.WriteAllLines("Invoices.txt", invoices.ToArray());
