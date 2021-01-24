    public class ReferencedStringExample
    {
        public void Wrong()
        {
            string GuestA = "Joe",
                GuestB = "Ben",
                GuestC = "Carl";
            var array = new string[]
            {
                GuestA,
                GuestB,
                GuestC
            };
            GuestA = "Joe Ho";
            Debug.Assert(GuestA == array[0]);            
        }
        public void Right()
        {
            Guest GuestA = "Joe",
                GuestB = "Ben",
                GuestC = "Carl";
            
            var array = new Guest[]
            {
                GuestA,
                GuestB,
                GuestC
            };
            GuestA.Val("Joe Ho");
            Debug.Assert(GuestA == array[0]);
            Debug.Assert(GuestA == "Joe Ho");
            GuestA = "Joe Ho";
            Debug.Assert(GuestA != array[0]);
            Debug.Assert(GuestA == "Joe Ho");
        }
        public class Guest
        {
            string value;
            public static implicit operator string(Guest g)
            {
                return g.value;
            }
            public static implicit operator Guest(string s)
            {
                return new Guest() { value = s };
            }
            public Guest Val(string s)
            {
                this.value = s;
                return this;
            }
            public override bool Equals(object obj)
            {
                Guest guest = obj as Guest;
                return guest.value == this.value;
            }
            public override int GetHashCode()
            {
                return (value ?? string.Empty).GetHashCode();
            }
        }
    }
