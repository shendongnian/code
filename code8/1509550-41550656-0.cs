    public static void Main(string[] args){
        var entityList = new List<Entity>();
        entityList.Add(new EntityObject()); 
  
        for(int i = 0; i < entityList.Count; i++) {
            if(entityList[i] is EntityObject)
                ((EntityObject)entityList[i]).position = Vector2.One;
            else if (entityList[i] is EntityCharacter)
                ((EntityCharacter)entityList[i].characterProperty = someValueToSet;
        }
