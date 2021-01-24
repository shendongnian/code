    class Program {
        static void Main(string[] args) {
            var table = new DataTable("MyTable");
            table.Columns.Add(new DataColumn("MyColumn"));
            var row = table.NewRow();
            Console.WriteLine($"Rowstate: {row.RowState}"); //Prints Detached
            table.Rows.Add(row);
            Console.WriteLine($"Rowstate: {row.RowState}"); //Prints Added
            table.AcceptChanges();
            Console.WriteLine($"Rowstate: {row.RowState}"); //Prints Unchanged
            row.BeginEdit();
            row[0] = "NewValue";
            row.EndEdit();
            Console.WriteLine($"Rowstate: {row.RowState}"); //Prints Modified
            if (row.HasVersion(DataRowVersion.Current)) { // Does the row contain uncommited values?
                Console.WriteLine($"DataRowVersion: {DataRowVersion.Current}"); //Prints Current
            }
            table.AcceptChanges(); //Commit all DataRowChanges
            if (row.HasVersion(DataRowVersion.Original)) {
                Console.WriteLine($"DataRowVersion: {DataRowVersion.Original}"); //Prints Current
            }
            Console.ReadLine();
        }
    }
