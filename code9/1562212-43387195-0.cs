    public struct Length
    {
        public readonly decimal Value;
        public Length(decimal length)
        {
            Value = length;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Length))
            {
                return false;
            }
            return Value == ((Length)obj).Value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public static explicit operator Length(decimal value)
        {
            return new Length(value);
        }
        public static explicit operator decimal(Length length)
        {
            return length.Value;
        }
        public static Length operator+(Length length1, Length length2)
        {
            return new Length(length1.Value + length2.Value);
        }
    }
    public struct Angle
    {
        public readonly decimal Value;
        public Angle(decimal angle)
        {
            Value = angle;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Angle))
            {
                return false;
            }
            return Value == ((Angle)obj).Value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public static explicit operator Angle(decimal value)
        {
            return new Angle(value);
        }
        public static explicit operator decimal(Angle angle)
        {
            return angle.Value;
        }
        public static Angle operator +(Angle angle1, Angle angle2)
        {
            return new Angle(angle1.Value + angle2.Value);
        }
    }
    public static Length Perimeter(Length length1, Length length2, Length length3)
    {
        return length1 + length2 + length3;
        // Or
        //return new Length(length1.Value + length2.Value + length3.Value);
    }
