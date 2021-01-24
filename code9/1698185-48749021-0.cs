    public abstract class Armor
    {
        public abstract void Equip( MainCharacterEquipment mce ){};
    }
    public class HeadArmor : Armor
    {
        public override void Equip( MainCharacterEquipment mce )
        {
             mce.HeadSlot=this;
        }
    }
    public class ChestArmor : Armor
    {
        public override void Equip( MainCharacterEquipment mce )
        {
             mce.ChestSlot=this;
        }
    }
