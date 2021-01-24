    public string getNumber(List<Node> currentList, string name)
    {
        foreach (var item in currentList)
        {
            if (item.Header == name)
            {
                return item.Number;
            }
        }
        
       foreach (var item in currentList)
       {
           string number = getNumber(item.Nodes, name);
           if (number != null)
           {
               return number;
           }
       }
       return null;
    }
