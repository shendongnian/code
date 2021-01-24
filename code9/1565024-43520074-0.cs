                                     RiskDescription2 = c.Field<dynamic>("Risk description "),
                                    
                                     
                                 } into g
                                 where g.Count() > 1
                                 select new
                                 {
                                     g.Key.RiskDescription2,
                                    
                                     //  g.Key.Pin,
                                     Noofrec = g.Count()
                                 };
                    if (result.ToList().Count > 0)
                    {
                        lblErrMsg.Visible = true;
                        div_err_log.Visible = false;
                        lblErrMsg.Text = "Risk with same description not allowed.";
                        return;
                    }
