     public class SOF45114671Controller : Controller
        {
            // GET: SOF45114671_
            public ActionResult Index()
            {
                return View();
            }
    
            private List<CICO> GetCICO(List<SqlParameter> queryParams)
            {
                string str = string.Empty;
                List<CICO> cicos = new List<CICO>();
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = str;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 180;
                        string q = " SELECT distinct i.ssn_or_tin,i.cusid,i.accountNo,i.dateTrans,i.transCode,i.transdescription_1,(i.debit) as amount,(coalesce(c.debit, 0)) as cashin,(coalesce(o.debit, 0)) as cashout,i.source";
                        q += " FROM source_ips i ";
                        q += " LEFT JOIN (SELECT * FROM source_cash_in_original where transCode = '966') as c ON(i.ssn_or_tin = c.ssntin or i.cusid = c.cusid or i.accountNo = c.accountNo) and i.dateTrans = c.dateTrans";
                        q += " LEFT JOIN(select * from source_cash_out_original where transCode = '936') as o on(i.ssn_or_tin = o.ssntin or i.cusid = o.cusid or i.accountNo = o.accountNo) and i.dateTrans = o.dateTrans";
                        q += " WHERE (i.ssn_or_tin = @ssn_or_tin OR @ssn_or_tin='' ) and i.transCode = '131' and(i.dateTrans between '1/22/2015' and '1/22/2015') order by i.dateTrans ASC";
    
                        cmd.Parameters.AddRange(queryParams.ToArray());
                        cmd.CommandText = q;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    CICO cico = new CICO()
                                    {
                                        ssn_or_tin = sdr["ssn_or_tin"] == DBNull.Value ? (double?)null : Convert.ToDouble(sdr["ssn_or_tin"]),
                                        cusid = sdr["cusid"] == DBNull.Value ? (double?)null : Convert.ToDouble(sdr["cusid"]),
                                        accountNo = sdr["accountNo"] == DBNull.Value ? (double?)null : Convert.ToDouble(sdr["accountNo"]),
                                        dateTrans = sdr["dateTrans"].ToString(),
                                        transCode = sdr["transCode"] == DBNull.Value ? (int?)null : Convert.ToInt32(sdr["transCode"]),
                                        transdescription_1 = sdr["transdescription_1"].ToString(),
                                        amount = sdr["amount"] == DBNull.Value ? (double?)null : Convert.ToDouble(sdr["amount"]),
                                        cashin = sdr["cashin"] == DBNull.Value ? (double?)null : Convert.ToDouble(sdr["cashin"]),
                                        cashout = sdr["cashout"] == DBNull.Value ? (double?)null : Convert.ToDouble(sdr["cashout"]),
                                        source = sdr["source"].ToString()
                                    };
                                    cicos.Add(cico);
                                }
                            }
                        }
                        con.Close();
                    }
                }
                return cicos;
            }
    
            [HttpPost]
            public JsonResult GetAllCICO(SearchParameters searchParameters = null)
            {
                searchParameters = searchParameters ?? new SearchParameters();
    
                // this lines get info from your DB
                //List<SqlParameter> parameters = searchParameters.ToSqlParameterList();
                //var cicos = this.GetCICO(parameters).ToList();
    
                //this lines is my My db - you can remove
                var cicoreps = new List<CICO>();
                cicoreps.Add(new CICO { ssn_or_tin = 1, accountNo = 1 });
                cicoreps.Add(new CICO { ssn_or_tin = 2, accountNo = 2 });
                // this line emulate your query into DB - you can remove
                var cicos = cicoreps.Where(i => i.ssn_or_tin.ToString() == searchParameters.ssn_or_tin || string.IsNullOrEmpty(searchParameters.ssn_or_tin) ).ToList();
    
    
                //your code
                var jsonResult = Json(new { data = cicos }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }
