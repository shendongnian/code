      public class F1P1X
      {
         public string Feature { get; set; }
         public string Point { get; set; }
         public string Coordinates { get; set; }
      }
      public static void Test()
      {
         F1P1X[] test1Array = new[] 
         {
            new F1P1X
            {
               Feature = "F1",
               Point = "P1",
               Coordinates = "X1"
            },
            new F1P1X
            {
               Feature = "F2",
               Point = "P2",
               Coordinates = "X2"
            },
         };
         F1P1X[] test2Array = new[] 
         {
            new F1P1X
            {
               Feature = "F3",
               Point = "P3",
               Coordinates = "X3"
            },
            new F1P1X
            {
               Feature = "F4",
               Point = "P4",
               Coordinates = "X4"
            },
         };
         
         F1P1X[][] test = {test1Array, test2Array};
         F1P1X[][] test2 = { test1Array, test2Array };
         F1P1X[][][] top = {test, test2};
         //array of arrays of arrays as JSON
         string json = JsonConvert.SerializeObject(top);
         List<F1P1X[][]> arrays = JsonConvert.DeserializeObject<F1P1X[][][]>(json).ToList();
         foreach (F1P1X[][] item in arrays)
         {
            foreach (F1P1X[] f1P1X in item)
            {
               foreach (F1P1X p1X in f1P1X)
               {
                  //do some magic 
               }
            }
         }
         // or use linq
         var result = arrays.SelectMany(x => x.SelectMany(y => y.Where(z => z.Coordinates == "X1")));
      }
