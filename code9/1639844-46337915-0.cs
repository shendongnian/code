    theEdges.GroupBy(variable => new { 
        OriginX = variable.Value.Origin.PositionCoordinates.X, 
        OriginY = variable.Value.Origin.PositionCoordinates.Y,
        DestX = variable.Value.Destination.PositionCoordinates.X,
        DestY = variable.Value.Destination.PositionCoordinates.Y })
