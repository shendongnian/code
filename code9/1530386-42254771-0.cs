    interface IHasId { int Id {get;}}
    interface ILoadable<TData> { void Load(TData data);}
    void LoadItem<TSettings, TData>(int id, GameObject tile, TileType tileType) 
           where : TSettings : ILoadable<TData>, TData : IHasId
    { 
        TSettings  settings = tile.GetComponent<TSettings>();
        foreach (TData data in DataBase(tileType))
        {
            if (data.Id = id)
            {
                settings.Load(data);
                break;
            }
        }
    }
    
    class WallSettings : ILoadable<WallTileData>, ...
    class WallTileData : IHasId,...
   
