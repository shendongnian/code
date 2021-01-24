        public class RiskFactorModel
        {
            public static List<RiskFactorModel> LowRiskFactorModel { get; set; }
            public string RiskFactorName { get; set; }
            public List<string> RiskFactorNameChild { get; set; }
            public void Update()
            {
                var groups = LowRiskFactorModel.GroupBy(x => x.RiskFactorName).ToList();
                LowRiskFactorModel = groups.Select(x => new RiskFactorModel()
                {
                    RiskFactorName = x.Key,
                    RiskFactorNameChild = x.Select(y => y.RiskFactorNameChild.Select(z => z)).SelectMany(y => y).Distinct().ToList()
                }).ToList();
            }
        }
