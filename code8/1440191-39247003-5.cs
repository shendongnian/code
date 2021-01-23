    public int GetNumberOfSeats(string aircraftModel)
    {
        var p = (from element in XDocument.Load("data.xml").Descendants("Aircraft")
                 let type = element.Attribute("ID").Value
                 where type.Equals(aircraftModel)
                 select type == "B747" ? 100 :
                        type == "A320" ? 200 : 0).FirstOrDefault();
        return p;
    }
    
    public void assignFirstClass()
    {
        var p = GetNumberOfSeats("B747");
        bool[] seats = new bool[p];
    
        //Rest of code
    }
