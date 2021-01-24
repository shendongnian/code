    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<CUSTPACKINGSLIPVERSIONs> CUSTPACKINGSLIPVERSION = new List<CUSTPACKINGSLIPVERSIONs>();
                List<CUSTPACKINGSLIPJOURs> CUSTPACKINGSLIPJOUR = new List<CUSTPACKINGSLIPJOURs>();
                List<CUSTPACKINGSLIPTRANSs> CUSTPACKINGSLIPTRANS = new List<CUSTPACKINGSLIPTRANSs>();
                var VerId = (from vId in CUSTPACKINGSLIPVERSION
                             join slipId in CUSTPACKINGSLIPJOUR on vId.INTERNALPACKINGSLIPID equals slipId.RECID
                             join cId in CUSTPACKINGSLIPTRANS on vId.INTERNALPACKINGSLIPID equals cId.PACKINGSLIPID
                             select new { vid = vId, slipId = slipId, cId = cId })
                             .GroupBy(x => x.vid.VERSIONDATETIME)
                             .OrderBy(x => x.Key)
                             .FirstOrDefault()
                             .Select(x => new { linenum = x.cId.LINENUM, recid = x.cId.RECID })
                             .ToList();
            }
        }
        public class CUSTPACKINGSLIPVERSIONs
        {
            public int INTERNALPACKINGSLIPID { get; set; }
            public DateTime VERSIONDATETIME { get; set; }
        }
        public class CUSTPACKINGSLIPJOURs
        {
            public int RECID { get; set; }
            public int PACKINGSLIPID { get; set; }
        }
        public class CUSTPACKINGSLIPTRANSs
        {
            public int PACKINGSLIPID { get; set; }
            public int LINENUM { get; set; }
            public int RECID { get; set; }
        }
    }
