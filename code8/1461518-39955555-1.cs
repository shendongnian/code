    public class Building
    {
        public Building(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
        }
        public int SizeX { get; }
        public int SizeY { get; }
    }
    public static class BuildingProperties
    {
        public static Building House { get; } = new Building(4, 4);
        public static Building House1 { get; } = new Building(6, 6);
        public static Building Commercial { get; } = new Building(10, 10);
        
    }
