    void Main()
    {
    	var map = new CellInfo[10, 10];
    	for (int x = 0; x < 10; x++)
    	{
    		for (int y = 0; y < 10; y++)
    		{
    			map[x, y] = new CellInfo();
    		}
    	}
    
    	var rnd = new Random();
    	for (int i = 0; i < 20; i++)
    	{
    		map[rnd.Next(0, 10), rnd.Next(0, 10)].IsBlocked = true;
    	}
    
    	DrawMap(map).Dump();
    }
    
    public Bitmap DrawMap(CellInfo[,] map)
    {
    	var img = new Bitmap(320, 320, PixelFormat.Format32bppArgb);
    	using (var g = Graphics.FromImage(img))
    	{
    		for (int x = 0; x < 10; x++)
    		{
    			for (int y = 0; y < 10; y++)
    			{
    				var cell = map[x, y];
    				Brush brush = cell.IsBlocked ? Brushes.Red : Brushes.White;
    				g.FillRectangle(brush, x * 32, y * 32, 31, 31);
    				g.DrawRectangle(Pens.Black, x * 32, y * 32, 31, 31);
    			}
    		}
    	}
    	return img;
    }
    
    public class CellInfo
    {
    	public bool IsBlocked { get; set; } = false;
    }
