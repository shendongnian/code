    private void CreatePivotView()
        {
            MyDbContext db = new MyDbContext();
            DataTable dt = db.ViewStatus; // get data from ViewStatus that is in your database
            int count = 1;
            String query = "CREATE VIEW IF NOT EXISTS PivotView AS SELECT DISTINCT(Machine) AS 'Machine', ";
            foreach (DataRow dr in dt.Rows)
            {
                query += "(SELECT status FROM StatusView WHERE ServiceId=" + dr["ServiceId"] + ") AS 'Service " + dr["ServiceId"] + "'";
                if (dt.Rows.Count != count)
                {
                    query += ";";
                }
                else
                {
                    query += " ";
                }
                count++;
            }
            query += "from SimpleView";
            db.Database.ExecuteSqlCommand(query);
        }
