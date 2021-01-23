        public class Beast : Enemy    
        {
            public Beast(HP, Attack, Defense, Name) {
                this.HP = HP;
                this.Attack = Attack;
                this.Defense = Defense;
                this.Name = Name;
            }
        }
        public class Bear : Beast
        {
            public Bear() {
                Beast(120, 20, 15, "Bear");
            }
        }
