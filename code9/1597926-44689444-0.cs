    using System.Data;
    namespace ConsoleApplication1
    {
    class Program
    {
        static DataTable Dt;
        static void Main(string[] args)
        {
            Dt = new DataTable();
            Dt.Columns.Add(new DataColumn("date", typeof(DateTime)));
            Dt.Columns.Add(new DataColumn("Serial Number", typeof(int)));
            AddRow(Dt.NewRow(), new DateTime(2017, 06, 22), 2);
            
            AddRow(Dt.NewRow(), new DateTime(2017, 06, 22), 1);
            AddRow(Dt.NewRow(), new DateTime(2017, 06, 20), 2);
            AddRow(Dt.NewRow(), new DateTime(2017, 06, 20), 1);
            foreach(DataRow dr in Dt.Rows)
            {
                Console.WriteLine(string.Format("{0}\t{1}", dr[0], dr[1]));
            }
            DataView dv = Dt.DefaultView;
            dv.Sort = "date, Serial Number";
            foreach(DataRow dr in dv.ToTable().Rows)
            {
                Console.WriteLine(string.Format("{0}\t{1}", dr[0], dr[1]));
            }
            Console.ReadKey();
        }
        static void AddRow(DataRow dr, DateTime dt, int serialNumber)
        {
            dr[0] = dt;
            dr[1] = serialNumber;
            Dt.Rows.Add(dr);
        }
    }
    }
