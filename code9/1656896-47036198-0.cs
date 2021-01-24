        public class Test
        {
            public MainObj MainObjList { get; set; }
            public Test()
            {
                var groups = from a in MainObjList.ObjAList
                             join b in MainObjList.ObjBList on a.ID1 equals b.ID1
                             where a.ID2 == b.ID2
                             select new { a = a, b = b };
               
            }
            public class MainObj
            {
               public  List<ObjA> ObjAList { get; set; }
               public  List<ObjB> ObjBList { get; set; }
            }
            public class ObjA
            {
                public int ID1 { get; set; }
                public int ID2 { get; set; }
                public void DoSomething()
                {
                    //Do something Here
                }
            }
            public class ObjB
            {
                public int ID1 { get; set; }
                public int ID2 { get; set; }
            }
        }
