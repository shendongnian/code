    public class ItemFactory : Item {
    
      private Item item;
    
      public ItemFactory() { }
    
      public Item makeItem(int type)
      {
          
        if(type == 1)
        {
          item = new Weapon();
          sprite = Weapon.getSprite();
        }
        else
        {
          item = new Armor();
          sprite = Armor.getSprite();
        }
        return item;
      }
    
      public Sprite getItemSprite()
      {
        return sprite;
      }
    }
