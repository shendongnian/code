    bool Ismatch=false;
    
    DataTable dt = new DataTable;
                int FilteCarriercount = (from q in dt.AsEnumerable()
                                       where q.Field<string>("Date").ToString().Split('/')[0] == txtmonth.Text &&
                                       q.Field<string>("Date").ToString().Split('/')[2] == txtyear.Tex
                                          select new 
                                          {
                                              date = Utility.IsnullorEmpty(q["Date"]),
                                          }).ToList().Count;
    If(FilteCarriercount >0)
    {
      lblmessage("You Uploaded Valid document");
    }
    else
    {
      lblmessage("You Uploaded is not Valid document");
    }
