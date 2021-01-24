    public IActionResult Index()
    {
        int w = 3, h = 2;
        var matrix = new Matrix();
        matrix.Data = new int[w][];
        for (int i = 0; i < w; i++)
            matrix.Data[i] = new int[h];
    
        return View(matrix);
    }
    
    [HttpPost]
    public IActionResult Index(Matrix matrix)
    {
        return View(matrix);
    }
