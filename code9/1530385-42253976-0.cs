    public abstract class GameObject 
    {
        public virtual void LoadSettings(int id)
        {
            var tileType =
                this is Fish? TileType.Fish:
                this is Wall? TileType.Wall: TypeType.Null;
            var settings = 
                this is Fish? tile.GetComponent<FishSettings>():
                this is Wall? tile.GetComponent<WallSettings>():
                              null;
            foreach (var data in DataBase(tileType))
            {
                if (data.Id = id)
                {
                    settings.Load(data);
                    break;
                }
            }
        }
    }
    public class Fish: GameComponent
    {
        // rest of Fish class
    }
    public class Wall: GameComponent
    {
        // rest of Wall class
    }
