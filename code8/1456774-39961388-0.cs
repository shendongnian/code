    // item is the base, comment is a thread comment, reply is a comment to a comment
    public enum ItemType { Item, Thread, Comment, Reply }
    public class Item {
      [BsonId] public string Id { get; set; }
      [BsonElement("body")] public string Body { get; set; }
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      [BsonElement("type")] public virtual ItemType Type { get { return ItemType.Item; } }
      [BsonDefaultValue(null)]
      [BsonElement("parent")] public string ParentId { get; set; }
      [BsonDefaultValue(null)]
      [BsonElement("title")] public string Title { get; set; }
      public override string ToString() { return String.Format("{0};{1};{2};{3};{4}", Id, Type, ParentId, Body, Title); }
    }
    public class Thread : Item { public override ItemType Type { get { return ItemType.Thread; } } }
    public class Comment : Item { public override ItemType Type { get { return ItemType.Comment; } } } 
    public class Reply : Item { public override ItemType Type { get { return ItemType.Reply; } } }
