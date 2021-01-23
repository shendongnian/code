csharp
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
    public int ID { get; set; }
    public string Name { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public SlotTypes SlotType { get; set; }
}
