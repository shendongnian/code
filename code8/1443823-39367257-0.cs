    class Samurai 
    {    
        [Inject]
        public IWeapon Weapon { private get; set; }
      
        public void Attack(string target) 
        {
            this.Weapon.Hit(target);
        }
    }
