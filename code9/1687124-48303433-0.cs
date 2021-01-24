    [Serializable]
    public sealed class Warrior
    {
        private readonly Dictionary<int, int> weaponSkills = new Dictionary<int, int>();
        public void SetWeaponSkill(Weapon weapon, int skill)
        {
            weaponSkills[weapon.Key] = skill;
        }
        public int GetWeaponSkill(Weapon weapon)
        {
            int skill;
            if (!weaponSkills.TryGetValue(weapon.Key, out skill))
            {
                throw new ArgumentException("Warrior doesn't have weapon");
            }
            return skill;
        }
    }
    public static class Weapons
    {
        public static readonly Weapon Sword = new Weapon(1, "Sword");
        public static readonly Weapon Dagger = new Weapon(2, "Dagger");
    }
    public sealed class Weapon
    {
        public Weapon(int key, string text)
        {
            Key = key;
            Text = text;
        }
        public int Key { get; }
        public string Text { get; }
    }
