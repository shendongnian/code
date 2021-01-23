    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Dynamic;
    
    namespace Test
    {
        public class Piller
        {
            public int PillarId;
            public string Quarter;
            public string Feature;
        public static List<dynamic> Generate()
        {
            List<Piller> pillers = new List<Piller>();
            pillers.Add(new Piller { PillarId = 1, Quarter = "Q12106", Feature = "France" });
            pillers.Add(new Piller { PillarId = 1, Quarter = "Q12106", Feature = "Germany" });
            pillers.Add(new Piller { PillarId = 1, Quarter = "Q22016", Feature = "Italy" });
            pillers.Add(new Piller { PillarId = 1, Quarter = "Q32016", Feature = "Russia" });
            pillers.Add(new Piller { PillarId = 2, Quarter = "Q22016", Feature = "Italy" });
            pillers.Add(new Piller { PillarId = 2, Quarter = "Q32016", Feature = "USA" });
            pillers.Add(new Piller { PillarId = 3, Quarter = "Q22016", Feature = "China" });
            pillers.Add(new Piller { PillarId = 3, Quarter = "Q32016", Feature = "Australia" });
            pillers.Add(new Piller { PillarId = 3, Quarter = "Q32016", Feature = "New Zeland" });
            pillers.Add(new Piller { PillarId = 3, Quarter = "Q42016", Feature = "Japan" });
            var pillerIds = (from p in pillers
                            select p.PillarId).Distinct();
            var quarters = (from p in pillers
                            select p.Quarter).Distinct();
            List<dynamic> transformedData = new List<dynamic>();
            foreach (var pillerId in pillerIds)
            {
                var data = new ExpandoObject() as IDictionary<string, Object>;
                data.Add("pillerId",pillerId);
                foreach (var quarter in quarters)
                {
                    var features = (from p in pillers
                                    where p.PillarId == pillerId && p.Quarter == quarter
                                    select p.Feature);
                    data.Add(quarter,features);
                }
                transformedData.Add(data);
            }
            return transformedData;
        }
        public static void Print(List<dynamic> data)
        {
            var dic = data[0] as IDictionary<string, Object>;
            foreach (var field in dic.Keys)
            {
                Console.Write(field+" ");
            }
            Console.WriteLine();
            foreach (dynamic record in data)
            {
                dic = record as IDictionary<string, Object>;
                foreach (var field in dic.Keys)
                {
                    if (field == "pillerId")
                        Console.Write(dic[field] + " ");
                    else
                    {
                        var value = dic[field];
                        if (value == null)
                        {
                            Console.Write("      ");
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (var item in (value as IEnumerable<string>))
                            {
                                if (sb.Length == 0)
                                    sb.Append(item);
                                else
                                    sb.Append(","+item);
                            }
                            Console.Write(sb.ToString());
                        }
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
                
            }
        }
    }
}
