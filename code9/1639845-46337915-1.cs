    var atLeastOneItem = theEdges.GroupBy(v=> new { 
                                          OriginX = v.Value.Origin.PositionCoordinates.X, 
                                          OriginY = v.Value.Origin.PositionCoordinates.Y,
                                          DestX = v.Value.Destination.PositionCoordinates.X,
                                          DestY = v.Value.Destination.PositionCoordinates.Y })
                                 .Any(x => x.Any());
    
    if(atLeastOneItem)
    {
    
    }
