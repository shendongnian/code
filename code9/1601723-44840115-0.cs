    public class Effect
    {
        public static Effect CreateEffect()
        {
            if (!IsCreateable())
            {
                return null;
            }
            return new Effect();
            //Otherwise create the effect
        }
        public static bool IsCreateable()
        {
            //Some generic logic common amongst all Effects
            return true;
        }
    }
    public class Effect2 : Effect
    {
        public new static Effect CreateEffect()
        {
            if (!IsCreateable())
            {
                return null;
            }
            return new Effect();
            //Otherwise create the effect
        }
        public new static bool IsCreateable()
        {
            //Some generic logic common amongst all Effects
            return true;
        }
    }
