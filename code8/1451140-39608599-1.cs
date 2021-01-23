    string[] RegionalEarn = tickets["EARN"].ToString().Split(',');
    var sum =0;    
    foreach (var item in RegionalEarn)
    {
       var num = 0;
       if (Int32.TryParse(item.Split('=')[1], out num))
       {
           sum = sum + num;
       }
       else 
       {
           // log error, item.Split('=')[1] is not an int
       }
    }
    RModel.TAX = sum.ToString();
