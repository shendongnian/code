        List <string> items= new List<string>();
        items.Add("Item_001");
        items.Add("Item_002");
        items.Add("Item_003");
        items.Add("Item_004");
            string somthing = items[2];
        string item = items.FirstOrDefault(x => x.ToString() == somthing);
        int index = items.IndexOf(item);
        Response.Write("Value found at : "+(index+1).ToString() +" row and value is : "+item);
