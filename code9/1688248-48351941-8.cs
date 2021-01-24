	public interface ITileMap<out T> where T : Tile
	{
	}
	
	public class Tile
	{
        public ITileMap<Tile> tileMap { get; set; }
	}
	
	public class TileMap<T> : ITileMap<T> where T : Tile, new()
	{
		public TileMap()
		{
			T newTile = new T();
			newTile.tileMap = this;   //This compiles now!!! 
		}
		
		public override string ToString()
		{
			return "Hello world!!!";
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			var t = new TileMap<Tile>();
			Console.WriteLine(t);
		}
	}
