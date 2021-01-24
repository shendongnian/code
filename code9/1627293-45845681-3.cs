    List <Sentence> sentences;
    foreach (Charge chg in charges)
    {
        List <Sentence> sentencesForThisCharge = MyLib.IAdapters.SentenceAdapter.GetByChargeObjectID(chg.ChargeObjectID);
        if (null != sentencesForThisCharge) 
        {
            sentences.Add(sentencesForThisCharge);
        }
    }
    
    rpt1.DataSource = sentences;
    rpt1.DataBind();
