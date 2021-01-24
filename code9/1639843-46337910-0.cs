     private bool EdgeCollectionIsAppropriate(Dictionary<int, DijkstraEdge> theEdges)
         {
        
            if (theEdges.GroupBy(variable => new { A=variable.Value.Origin.PositionCoordinates.X, B=variable.Value.Origin.PositionCoordinates.Y,C=variable.Value.Destination.PositionCoordinates.X, D=variable.Value.Destination.PositionCoordinates.Y }).Any(x=>x.Count()>1))
        
        
            {
                logger.Debug("The edges list contains 2 or more edges with same destnation and origin position");
                return false;
            }
        
            return true;
        }
