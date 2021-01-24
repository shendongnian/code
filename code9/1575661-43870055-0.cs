     public string ParseMapObjects()
     {  
            List<MapObjectEntity> MapObjects = new List<MapObjectEntity>();
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(MapObjects);
        }
