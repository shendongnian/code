    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ReadIList
    {
        class Program
        {
            static void Main(string[] args)
            {
                mainclass mc = new mainclass();
                mc.CheckRights();
                secondclass sc = new secondclass();
                sc.CheckRights(string.Empty);
            }
        }
        public class ListTable
        {
            public static  IList<object> rolelist = new List<object>();
    
            public IList<object> GetList()
            {
                return rolelist;
            }
        }
    
        public class mainclass
        {
            ListTable rolelist = new ListTable();
            private ListTable myClass= new ListTable();
            public void CheckRights()
            {
                IList<object> testlist = myClass.GetList();
                testlist.Add(new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 });   
            }
        }
    
        public class secondclass
        {
            private ListTable list=new ListTable();
            public void CheckRights(string username)
            {
                IList<object> called = list.GetList();
                foreach (object[] item in called)
                {
                   
                    Console.WriteLine(item[1].ToString());
                }
                Console.ReadLine();
            }
        }
    }
