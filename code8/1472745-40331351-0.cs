    if (ContainsCoordinates(SouthEastNeighbor))
        {
            if (Maze.Instance.cellStorage[SouthEastNeighbor.x, SouthEastNeighbor.z].IsWalkable)
            {
                MazeCell c = Maze.Instance.cellStorage[SouthEastNeighbor.x, SouthEastNeighbor.z];
                if (!(c.cellEdges[(int)MazeDirection.South] is MazeCellWall) && !(c.cellEdges[(int)MazeDirection.East] is MazeCellWall))
                {
                    Node vn = PrepareNewNode(node, 0, -1);
                    neighbors.Add(vn);
                }
            }
        }
