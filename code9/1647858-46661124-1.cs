    Command.CommandText = "SELECT productid, (select name from menu where id = productid)as Foodname, price, quantity, price * quantity as total from salesdetail where salesid = (select id from booking where secret = 'ypnok3bd' and id = 'SSD00000000000000001') ";
    using(var rd = Command.ExecuteReader())
    {
        if(rd.Read())
        {
           string productid = rd.GetInt32(0).ToString();
           string foodname = rd.GetString(1);
           string price = rd.GetDecimal(2).ToString();
           string total = rd.GetDecimal(3).ToString();
       }
    }
        
