    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("S1 no", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("15-Jan-18", typeof(int));
                dt.Columns.Add("19-Jan-18", typeof(int));
                dt.Columns.Add("21-Jan-18", typeof(int));
                dt.Rows.Add(new object[] { 1, "AppyBiju", 7, null, 2 });
                dt.Rows.Add(new object[] { 2, "Sasi", 4, 9, null });
                dt.Rows.Add(new object[] { 3, "Soman", 8, 6, null });
                dt.Rows.Add(new object[] { 4, "Pakkaran", 2, null, 2 });
                dt.Rows.Add(new object[] { 5, "Koran", 5, null, 1 });
                DataRow totalRow =  dt.Rows.Add();
                totalRow[1] = "Total";
                
                foreach (DataColumn c in dt.Columns.Cast<DataColumn>().Skip(2))
                {
                    //method 2
                    int sum = 0;
                    for (int j = 0; j < dt.Rows.Count - 1; j++)
                    {
                        if (dt.Rows[j][c] != DBNull.Value)
                            sum += Convert.ToInt32(dt.Rows[j][c]);
                    }
                    totalRow[c] = sum;
                }
            }
        }
    }
