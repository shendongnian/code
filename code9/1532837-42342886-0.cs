        public class ICF
        {
            public static List<ICF> icfList = new List<ICF>();
            #region
            public int Flag { get; set; }
            public string ClaimID { get; set; }
            public string SeasonCode { get; set; }
            public string PlotNumber { get; set; }
            public string RyotNumber { get; set; }
            public string RyotName { get; set; }
            public string ClaimDate { get; set; }
            public string ClaimFormNo { get; set; }
            public string ClaimArea { get; set; }
            public string ClaimAmount { get; set; }
            public string ClaimReason { get; set; }
            public string SurveyorID { get; set; }
            public string SurveyorDate { get; set; }
            public string InsuranceAmount { get; set; }
            #endregion
            public static void AddRow(DataRow dr)
            {
                    ICF obj = new ICF();
                    obj.Flag = Convert.ToInt32(dr["Flag"]);
                    obj.ClaimID = dr["ClaimID"].ToString();
                    obj.RyotNumber = dr["RyotNumber"].ToString();
                    obj.SeasonCode = dr["SeasonCode"].ToString();
                    obj.PlotNumber = dr["PlotNumber"].ToString();
                    obj.RyotNumber = dr["RyotNumber"].ToString();
                    obj.RyotName = dr["RyotName"].ToString();
                    obj.ClaimDate = dr["ClaimDate"].ToString();
                    obj.ClaimFormNo = dr["ClaimFormNo"].ToString();
                    obj.ClaimArea = dr["ClaimArea"].ToString();
                    obj.ClaimAmount = dr["ClaimAmount"].ToString();
                    obj.ClaimReason = dr["ClaimReason"].ToString();
                    obj.SurveyorID = dr["SurveyorID"].ToString();
                    obj.SurveyorDate = dr["SurveyorDate"].ToString();
                    obj.InsuranceAmount = dr["InsuranceAmount"].ToString();
                    icfList.Add(obj);
            }
        }
