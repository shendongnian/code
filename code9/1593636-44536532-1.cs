    public class ItemToModelMapper
    {
        public SerializableItemModel MapToModel(Item item)
        {
            var model = new SerializableItemModel
            {
                Position = item.transform.position;
                Rotation = item.transform.rotation;
                Value = item._value;
            };
            return model
        }
        public Item MapFromModel(SerializableItemModel model)
        {
            return new Item(model.Position, model.Rotation, model.Value);
        }
    }
