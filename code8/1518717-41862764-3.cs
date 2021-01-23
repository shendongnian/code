    // Insert your grid/grid item code here ..
    Grid<int> grid = new Grid<int>();
    GridItem<int> item = grid.Cells[1];
    
    // Get top neighbor
    GridItem<int> neighbor = item.GetNeighbor(Direction.Top);
    
    // Check if top neighbor exists
    bool topNeighborExists = item.GetNeighbor(Direction.Top) != null;
