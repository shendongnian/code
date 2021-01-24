    public List<Table> GetTableFromSpecifiedDB(DbContext context, string db) {
            List<Table> table;
            if(db == "firstEntity")
            {
                table = ((FirstEntity)context).Table.ToList();
            }
            else
            {
                table = ((SecondEntity)context).Table.ToList();
            }
            
           return table
        }
