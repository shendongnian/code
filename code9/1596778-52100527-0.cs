    public static void HighlightShape(Shape shape)
    {
        if (shape == null) {
            return;
        }
        var processList = new Queue<Shape>();
        processList.Enqueue(shape);
        var allShapes = new List<Shape>();
        allShapes.Add(shape);
        while (processList.Count > 0) 
        {
            var s = processList.Dequeue();
            allShapes.Add(s);
            if (s.Shapes != null) {
                foreach (Shape subshape in s.Shapes) {
                    processList.Enqueue(subshape);
                }
            }
        }
        foreach (Shape s in allShapes) 
        {
            s.CellsU["LineColor"].FormulaForceU = "THEMEGUARD(RGB(255,255,0))";
        }
    }
