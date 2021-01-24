	public class TileOnlyMap : TileMap<Tile>
	{
		public TileOnlyMap()
		{
			Tile newTile = new Tile();
			newTile.tileMap = this;
		}
	}
	
