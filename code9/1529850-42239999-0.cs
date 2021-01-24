    public class ItemsRepository {
        public ItemDto Get(int id) {
           return _itemContextService.Items.FirstOrDefault(i => i.Id == id)
                    .ToDto();            
        }
    }
