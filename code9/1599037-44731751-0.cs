    private void drawGrid()
    {
        int numOfCells = 100;
        int cellSize = 50;
        Pen p = new Pen(Color.Blue);
    
        int left = 50;// Left
        int top = 10;//  Top
        int width = cellSize * numOfCells;
        int height = cellSize * numOfCells;
    
            for (int i = 0; i <= numOfCells; i++)
            {
                // Vertical
                paper.DrawLine(p, i * cellSize + left, top, i * cellSize + left, height + top);
                // Horizontal
                paper.DrawLine(p, left, i * cellSize + top, width + left, i * cellSize + top);
    
            }
    }
