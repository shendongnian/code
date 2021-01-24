    public class ItemToModelMapper
    {
        public SerializableItemModel MapToModel(Item item)
        {
            var model = new SerializableItemModel
            {
                position = item.transform.position;
                rotation = item.transform.rotation;
                _value = item._value;
            };
            return model
        }
        public Item MapFromModel(SerializableItemModel model)
        {
            return new Item(model.position, model.rotation, model._value);
        }
    }
