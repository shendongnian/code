    using System.Linq;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main (string[] args)
            {
                var salesmanList = new Salesman[]
                {
                    new Salesman ("Betty", 50, 6),
                    new Salesman ("Cindy", 40, 8),
                    new Salesman ("Doris", 70, 2),
                    new Salesman ("Emily", 30, 3),
                };
                var rankByKPI1 = salesmanList.OrderByDescending (x => x.KPI1)
                                             .Select ((x, index) => new SalesmanKpiRank (x, index + 1))
                                             .ToArray (); // for debugging only
                var rankByKPI2 = salesmanList.OrderByDescending (x => x.KPI2)
                                             .Select ((x, index) => new SalesmanKpiRank (x, index + 1))
                                             .ToArray (); // for debugging only
                var overallScoreQuery = from salesman in salesmanList
                                        let  kpi1rank = rankByKPI1.Single (x => x.Salesman.Equals (salesman)).Rank
                                        let  kpi2rank = rankByKPI2.Single (x => x.Salesman.Equals (salesman)).Rank
                                        select new SalesmanOverallScore (salesman, kpi1rank, kpi2rank);
                var rankByOverallScore = overallScoreQuery.OrderByDescending (x => x.Score)
                                                          .Select ((x , index) => new { SalesmanOverallScore = x, OverallRank = index + 1});
                var result = rankByOverallScore.ToArray ();               
            }
        }
        class Salesman
        {
            public Salesman (string id, int kpi1, int kpi2)
            {
                ID   = id;
                KPI1 = kpi1;
                KPI2 = kpi2;
            }
            public string ID   { get; }
            public int    KPI1 { get; }
            public int    KPI2 { get; }
            public override bool Equals (object obj) =>ID == ((Salesman) obj).ID; // put some logic here
            public override string ToString () => $"{ID} KPI1 = {KPI1}, KPI2 = {KPI2}";
        }
        class SalesmanKpiRank
        {
            public SalesmanKpiRank (Salesman salesman, int rank)
            {
                Salesman = salesman;
                Rank     = rank;
            }
            public Salesman Salesman { get; }
            public int      Rank     { get; }
            public override string ToString () => $"{Salesman} KPI Rank = {Rank}"; // kpi1 or kpi2
        }
        class SalesmanOverallScore
        {
            public SalesmanOverallScore (Salesman salesman, int kpi1rank, int kpi2rank)
            {
                Salesman = salesman;
                KPI1Rank = kpi1rank;
                KPI2Rank = kpi2rank;
            }
            public Salesman Salesman { get; }
            public int      KPI1Rank { get; }
            public int      KPI2Rank { get; }
            public double Score => (KPI1Rank + KPI2Rank) / 2d;
            public override string ToString () => $"{Salesman.ID} {Score}";
        }
    }
