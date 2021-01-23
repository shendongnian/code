    [Serializable]
    public class EquipementItem
    {
        public enum ItemTypes
        {
            None,
            Armor,
            Weapon
        }
        public enum SlotTypes
        {
            Head,
            Shoulders,
            Chest,
            Bracers,
            Gloves,
            Waist,
            Legs,
            Boots,
            Weapon
        }
        public int ID;
        public string Name;
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemTypes ItemType;
        [JsonConverter(typeof(StringEnumConverter))]
        public SlotTypes SlotType;
    }
