    if (charges != null && charges.Count > 0)
            {
                List<Sentence> sentences = new List<Sentence>();
                foreach (Charge chg in charges)
                {
                    sentences.AddRange(MyLib.IAdapters.SentenceAdapter.GetByChargeObjectID(chg.ChargeObjectID))
                    
                }
                rpt1.DataSource = sentences;
                rpt1.DataBind();
            }
