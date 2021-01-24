     public Task PerformSQLTasks()
        {
          FilteredCustomer.Clear();
          if(searchCritiria.Text.Length >= 3)
          {
            SQLiteConnection dbConnection = new SQLiteConnection("Customers.db");
            string sSQL = null;
                sSQL = @"SELECT [first],[last],[spouse],[home],[work],[cell] FROM Customers";
                ISQLiteStatement dbState = dbConnection.Prepare(sSQL);
            while (dbState.Step() == SQLiteResult.ROW)
            {
                string sFirst = dbState["first"] as string;
                string sLast = dbState["last"] as string;
                string sSpouse = dbState["spouse"] as string;
                string sHome = dbState["home"] as string;
                string sWork = dbState["work"] as string;
                string sCell = dbState["cell"] as string;
                //Load into observable collection
                if (searchType.SelectedIndex == 0)//name search
                {
                    if(sFirst.Contains(searchCritiria.Text) || sLast.Contains(searchCritiria.Text) || sSpouse.Contains(searchCritiria.Text))
                    FilteredCustomer.Add(new Customer {first = sFirst, last = sLast, spouse = sSpouse, home = sHome, work = sWork, cell = sCell});
                }
                else//number search
                {
                    if(sWork.Contains(searchCritiria.Text)|| sHome.Contains(searchCritiria.Text) || sCell.Contains(searchCritiria.Text))
                    FilteredCustomer.Add(new Customer { first = sFirst, last = sLast, spouse = sSpouse, home = sHome, work = sWork, cell = sCell });
                }
            }
        }
            return Task.CompletedTask;
     }
