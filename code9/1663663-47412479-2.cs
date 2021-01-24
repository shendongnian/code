    [CreateAssetMenu (fileName = "New Buff", menuName = "Data/Buff")]
    public class BuffData : ScriptableObject
    {
        public new string name;
        public string description;
        public Texture2D icon;
        public Buff [] attributeBuffs;
    }
