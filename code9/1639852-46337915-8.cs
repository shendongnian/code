    theEdges.GroupBy(v=> new { 
        OriginX = v.Value.Origin.PositionCoordinates.X, 
        OriginY = v.Value.Origin.PositionCoordinates.Y,
        v.Value.Destination.PositionCoordinates.X,
        v.Value.Destination.PositionCoordinates.Y })
