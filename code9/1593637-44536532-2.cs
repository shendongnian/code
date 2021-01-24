    public class SerializableItemModel
    {
        public Vector3 Position {get;set;}
        public Quaternion Rotation {get;set;}
        public float Value {get;set;}
        public SerializableItemModel(Item item)
        {
             this.Position = item.transform.position;
             this.Rotation = item.transform.rotation;
             this.Value = item.transform._value;
        }
    }
