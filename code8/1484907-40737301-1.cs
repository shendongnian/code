    [HttpPost]
    public ActionResult ApplyAC(ACModel Model, bool selector)
    {
        if (Selector)
        {
            var AddAC = Ac.Add(Model);//add data1 in model
        }
        else
        {
            var AddAC = Ac.Add(Model);//add a different data 
        }
    }
