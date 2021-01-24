    public class ObjectRelation
    {
        public ObjectRelation(GetObjectParentChildList_Result relation)
        {
            this.ObjectId = relation.Object_ID;
            this.Parent = relation.Parent_Object;
            this.ChildObjects = new List<ObjectRelation>();
        }
    
        public int ObjectId { get; set; }
        public ObjectRelation Parent { get; set; }
        public List<ObjectRelation> ChildObjects { get; set; }
    }
    
    public static class ObjectRelationExtensions
    {
      public static IEnumerable<ObjectRelation> Parents(this ObjectRelation obj)
      {
        while(obj.Parent!=null)
        {
          obj = obj.Parent;
          yield return obj;
        }
      }
    }
