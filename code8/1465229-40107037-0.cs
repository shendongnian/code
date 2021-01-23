    [HttpPost]
    [WebMethod]
    public void InsertScore(string Email ,string Row,char Answer)
    {
     if(Answer=='d')
        {
          Session["m"]="Hot";
        }
        if (Answer == 'r')
        {
          Session["m"]="Cold";
        }
    }
