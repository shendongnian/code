        Order newOrd = new Order();
    
        bazaDBDataContext db = new bazaDBDataContext();  
        //  insert into order table
        // int OrderID = return OrderID from DB
        for (int i = 1; i <= 10; i++)
            {
                List<string> listOfItems = new List<string>();
                listOfItems.Add(info0.Text);
                listOfItems.Add(OrderID);
                string res = Request.Form["dnn$ctr416$Order$inputInfo" + i];
                listOfItems.Add(res);
        
                for (int j = 0; j < listOfItems.Count; j++)
                {
                    string val = listOfItems[j];
                    newOrd.Info = val;
                }
            }
