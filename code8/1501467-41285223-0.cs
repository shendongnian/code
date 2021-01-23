    public void Test()
        {
            List<ARCUSO> arcuso = new List<ARCUSO>();
            arcuso.Add(new ARCUSO() {IDCUST = "10264", OPTFIELD = "ACCPACCUST", VALUE = "hj10264"});
            arcuso.Add(new ARCUSO() {IDCUST = "F1.10264", OPTFIELD = "ACCPACCUST", VALUE = "gg10264"});
            arcuso.Add(new ARCUSO() {IDCUST = "F2.10264", OPTFIELD = "ACCPACCUST", VALUE = "gg10264"});
            arcuso.Add(new ARCUSO() {IDCUST = "F4.10264", OPTFIELD = "ACCPACCUST", VALUE = "tt10264"});
            arcuso.Add(new ARCUSO() {IDCUST = "F3.4510264", OPTFIELD = "test", VALUE = "tt10264"});
            List<CWHDR> cwhdrs = new List<CWHDR>();
            cwhdrs.Add(new CWHDR() {TRANSSTTS = 2, IDVC = "10264"});
            cwhdrs.Add(new CWHDR() {TRANSSTTS = 2, IDVC = "F1.10264"});
            cwhdrs.Add(new CWHDR() {TRANSSTTS = 2, IDVC = "F2.10264"});
            cwhdrs.Add(new CWHDR() {TRANSSTTS = 2, IDVC = "F4.10264"});
            cwhdrs.Add(new CWHDR() {TRANSSTTS = 5, IDVC = "F3.4510264"});
            List<string> idcust = (from arc in arcuso
                where arc.VALUE.Contains("10264") && (arc.OPTFIELD == "ACCPACCUST")
                select arc.IDCUST).ToList();
            var data = (from ch in cwhdrs
                where idcust.Contains(ch.IDVC) && (ch.TRANSSTTS == 2)
                select new
                {
                    idvc = ch.IDVC
                }).ToList();
        }
