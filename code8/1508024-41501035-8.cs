    public string MyMethod(string coordinateId, string regionId)
    {
        if (!Coordinates.ContainsKey(regionId))
        {
            oordinates.Add(regionId, new Coordinate() {Id = regionId});
        }
        else
        {
            //Get the list of coordinates out of the dictionary for its region
            var list = Coordinates[regionId];
            if(list.Any(cor=> cor.Id == coordinateId))
            {   //Check if any of the coordinates have the same Id
                return "This coordinate id already exist for this region id";
            } else
            {  //Otherwise we add it to the list.
                lists.Add(new Coordinate() { Id = regionId})
            }
        }
        return "added";
    }
