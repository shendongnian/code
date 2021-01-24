    public ActionResult MyAction(string message)
    {
         // You can also use regular expressions
         var result = message.Replace("-0|||", "").Replace('|', '');
    }
