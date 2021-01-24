    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                StreamReader csvreader = new StreamReader(@"C:\testfile\Prod\PCDP1705.TAB");
                string inputLine = "";
                while ((inputLine = csvreader.ReadLine()) != null)
                {
                    var address = new Point();
                    string[] csvArray = inputLine.Split(new char[] { ',' });
                    address.postCodeID = int.Parse(csvArray[0]);
                    address.DPS = csvArray[1];
                    Point.deliveryPoints.Add(address);
                }
                //add data to datatable
                DataTable dt = new DataTable();
                dt.Columns.Add("Post Code", typeof(int));
                dt.Columns.Add("DPS", typeof(string));
                foreach (Point point in Point.deliveryPoints)
                {
                    dt.Rows.Add(new object[] { point.postCodeID, point.DPS });
                }
            }
        }
        public class Point
        {
            public static List<Point> deliveryPoints = new List<Point>();
            public int postCodeID { get; set; }
            public string DPS { get; set; }
        }
    }
