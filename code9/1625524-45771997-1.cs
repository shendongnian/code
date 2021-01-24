    private class tbl_GrandParent
    {
        public int GPID { get; set; }
        public string GP_Name { get; set; }
        public double GP_Wealth { get; set; }
    }
    private class tbl_Parent
    {
        public int PID { get; set; }
        public int GPID { get; set; }
        public string P_Name { get; set; }
        public double P_Wealth { get; set; }
    }
    private class tbl_Child
    {
        public int CID { get; set; }
        public int PID { get; set; }
        public string C_Name { get; set; }
        public double C_Wealth { get; set; }
    }
    private class tbl_WealthSpent
    {
        public int WSID { get; set; }
        public int CID { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
    private void Test()
    {
    
        try
        {
            List<tbl_GrandParent> gps = new List<tbl_GrandParent>();
            gps.Add(new tbl_GrandParent { GPID = 1, GP_Name = "GP_A TO D", GP_Wealth = 100 });
            gps.Add(new tbl_GrandParent { GPID = 2, GP_Name = "GP_E TO H", GP_Wealth = 100 });
            gps.Add(new tbl_GrandParent { GPID = 3, GP_Name = "GP_I TO L", GP_Wealth = 100 });
            List<tbl_Parent> ps = new List<tbl_Parent>();
            ps.Add(new tbl_Parent { PID = 1, GPID = 1, P_Name = "P_B", P_Wealth = 50 });
            ps.Add(new tbl_Parent { PID = 2, GPID = 1, P_Name = "P_c", P_Wealth = 50 });
            ps.Add(new tbl_Parent { PID = 3, GPID = 2, P_Name = "P_E", P_Wealth = 50 });
            List<tbl_Child> cs = new List<tbl_Child>();
            cs.Add(new tbl_Child { CID = 1, PID = 1, C_Name = "C_P_1.1", C_Wealth = 25 });
            cs.Add(new tbl_Child { CID = 2, PID = 1, C_Name = "C_P_1.2", C_Wealth = 25 });
            cs.Add(new tbl_Child { CID = 3, PID = 2, C_Name = "C_P_2.1", C_Wealth = 25 });
            List<tbl_WealthSpent> wss = new List<tbl_WealthSpent>();
            wss.Add(new tbl_WealthSpent { WSID = 1, CID = 1, FromTime = new DateTime(2017, 8, 19, 9, 0, 0), ToTime = new DateTime(2017, 8, 19, 10, 0, 0) });
            wss.Add(new tbl_WealthSpent { WSID = 3, CID = 1, FromTime = new DateTime(2017, 8, 19, 10, 0, 0), ToTime = new DateTime(2017, 8, 19, 11, 0, 0) });
            wss.Add(new tbl_WealthSpent { WSID = 4, CID = 1, FromTime = new DateTime(2017, 8, 19, 11, 0, 0), ToTime = new DateTime(2017, 8, 19, 12, 0, 0) });
            wss.Add(new tbl_WealthSpent { WSID = 5, CID = 3, FromTime = new DateTime(2017, 8, 19, 9, 0, 0), ToTime = new DateTime(2017, 8, 19, 10, 0, 0) });
            wss.Add(new tbl_WealthSpent { WSID = 7, CID = 3, FromTime = new DateTime(2017, 8, 19, 10, 0, 0), ToTime = new DateTime(2017, 8, 19, 11, 0, 0) });
    
            var details = from gp in gps
                            join p in ps on gp.GPID equals p.GPID into p_join
                            from p in p_join.DefaultIfEmpty()
                            join c in cs on p?.PID ?? 0 equals c.PID into c_join
                            from c in c_join.DefaultIfEmpty()
                            join ws in wss on c?.CID ?? 0 equals ws.CID into ws_join
                            from ws in ws_join.DefaultIfEmpty()
                            select new
                            {
                                GPID = gp.GPID,
                                GP_Name = gp.GP_Name,
                                GP_Wealth = gp.GP_Wealth,
                                PID = p?.PID ?? null,
                                CID = c?.CID ?? null,
                                FromTime = ws?.FromTime ?? null,
                                ToTime = ws?.ToTime ?? null
                            };
    
            var grp = details.GroupBy(x => new { x.GPID, x.GP_Name, x.GP_Wealth })
                                .Select(g => new
                                {
                                    GPID = g.Key.GPID,
                                    GP_Name = g.Key.GP_Name,
                                    GP_Wealth = g.Key.GP_Wealth,
                                    ChildCount = g.Where(x => x.PID != null).Select(x => x.PID).Distinct().Count(),
                                    GrandChildCount = g.Where(x => x.CID != null).Select(x => x.CID).Distinct().Count(),
                                    WealthSpent = g.Where(x => x.FromTime != null).Sum(t => ((TimeSpan)(t.ToTime - t.FromTime)).TotalSeconds / 3600)
                                });
        }
        catch (Exception ex)
        {
            MessageBox.Show("Exception thrown; " + ex.Message);
        }
    }
