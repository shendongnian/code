    public ActionResult MyAction(string operationType)
    {
        int result = 0;
        switch(operationType)
        {
            case "+":
                result = Int32.Parse(Request.Form["first"]) + Int32.Parse(Request.Form["second"]);
                break;
            case "-":
                break;
            case "/":
                break;
            case "*":
                break;
        }
    }
        
