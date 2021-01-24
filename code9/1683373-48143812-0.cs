    public class Food : Item {
        public float healthHealedOnUse;
    
        public override void Use(Player PHH) {
            PHH.Heal(healthHealedOnUse); 
        }
    }
