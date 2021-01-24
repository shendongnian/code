    public Parent(string sP1FN, string sP1LN, List<int> lCID)
    {
        sFirst_name1 = sP1FN;
        sLast_name1 = sP1LN;
        if (lCID == null)       
        {
           lChild_ID = new List<int>();
        }
        else
        {
           lChild_ID = lCID;
        }
    }
