    class Ability
    {
        public Ability(int cooldown, Action ab)
        {
            CoolDown = cooldown;
            TheAbility = ab;
        }
        public int CoolDown { get; set; }
        public Action TheAbility;
    }
    
    class Warrior : CharacterClass
    {
        public Warrior()
        {
            // Set the new Abilities
            AbilityOne = new Ability(3, Smash);
            AbilityTwo = new Ability(7, ShieldBlock);
            AbilityOne.TheAbility(); // Will run Smash() method
        }
    
        private void Smash()
        {
            // Ability 1
        }
    
        private void ShieldBlock()
        {
            // Ability 2
        }
    }
