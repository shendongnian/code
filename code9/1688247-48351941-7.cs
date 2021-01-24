	public class SpecificTypeOfTile : Tile
	{
	}
	
	public class TileOnlyMap : TileMap<Tile>
	{
		public TileOnlyMap()
		{
			var newTile = new Tile();
			newTile.tileMap = this;
			var newTile2 = new SpecificTypeOfTile();  //This works because of polymorphism
			newTile2.tileMap = this;
		}
	}
	
