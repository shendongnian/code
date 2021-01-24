    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var branchSettings = new BranchSettings();
                var branchOverviews = from bs in branchSettings.CompanyBranches
                    from bro in bs.Value.BrancheRuleOverviews
                    where bro.Key.PeriodName.Equals(int.Parse(args[0]))
                    select bro;
            }
        }
    
    
        public class BranchSettings
        {
            public Dictionary<Period, BrancheBO> CompanyBranches;
        }
    
    
        public class BrancheBO
        {
            /// <summary>
            /// Branche Rules per Period
            /// </summary>
            public Dictionary<Period, IEnumerable<BrancheRuleOverview>> BrancheRuleOverviews;
        }
    
        public class Period
        {
            public int PeriodName;
        }
    
        public class BrancheRuleOverview
        {
        }
    }
