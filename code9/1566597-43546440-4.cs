    [Serializable]
    [TypeConverter(typeof(UnitConverter))]
    public struct Unit
    {
        internal const int MaxValue = 32767;
        internal const int MinValue = -32768;
        public readonly static Unit Empty;
        private readonly UnitType type;
        private readonly double @value;
        public bool IsEmpty
        {
            get
            {
                return (int)this.type == 0;
            }
        }
        public UnitType Type
        {
            get
            {
                if (this.IsEmpty)
                {
                    return UnitType.Pixel;
                }
                return this.type;
            }
        }
        public double Value
        {
            get
            {
                return this.@value;
            }
        }
        static Unit()
        {
            Unit.Empty = new Unit();
        }
        public Unit(int value)
        {
            if (value < -32768 || value > 32767)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            this.@value = (double)value;
            this.type = UnitType.Pixel;
        }
        public Unit(double value)
        {
            if (value < -32768 || value > 32767)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            this.@value = (double)((int)value);
            this.type = UnitType.Pixel;
        }
        public Unit(double value, UnitType type)
        {
            if (value < -32768 || value > 32767)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            if (type != UnitType.Pixel)
            {
                this.@value = value;
            }
            else
            {
                this.@value = (double)((int)value);
            }
            this.type = type;
        }
        public Unit(string value) : this(value, CultureInfo.CurrentCulture, UnitType.Pixel)
        {
        }
        public Unit(string value, CultureInfo culture) : this(value, culture, UnitType.Pixel)
        {
        }
        internal Unit(string value, CultureInfo culture, UnitType defaultType)
        {
            if (string.IsNullOrEmpty(value))
            {
                this.@value = 0;
                this.type = (UnitType)0;
                return;
            }
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
            string lower = value.Trim().ToLower(CultureInfo.InvariantCulture);
            int length = lower.Length;
            int num = -1;
            for (int i = 0; i < length; i++)
            {
                char chr = lower[i];
                if ((chr < '0' || chr > '9') && chr != '-' && chr != '.' && chr != ',')
                {
                    break;
                }
                num = i;
            }
            if (num == -1)
            {
                object[] objArray = new object[] { value };
                throw new FormatException(SR.GetString("UnitParseNoDigits", objArray));
            }
            if (num >= length - 1)
            {
                this.type = defaultType;
            }
            else
            {
                this.type = Unit.GetTypeFromString(lower.Substring(num + 1).Trim());
            }
            string str = lower.Substring(0, num + 1);
            try
            {
                TypeConverter singleConverter = new SingleConverter();
                this.@value = (double)((float)singleConverter.ConvertFromString(null, culture, str));
                if (this.type == UnitType.Pixel)
                {
                    this.@value = (double)((int)this.@value);
                }
            }
            catch
            {
                object[] objArray1 = new object[] { value, str, this.type.ToString("G") };
                throw new FormatException(SR.GetString("UnitParseNumericPart", objArray1));
            }
            if (this.@value < -32768 || this.@value > 32767)
            {
                throw new ArgumentOutOfRangeException("value");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Unit))
            {
                return false;
            }
            Unit unit = (Unit)obj;
            if (unit.type == this.type && unit.@value == this.@value)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCodeCombiner.CombineHashCodes(this.type.GetHashCode(), this.@value.GetHashCode());
        }
        private static string GetStringFromType(UnitType type)
        {
            switch (type)
            {
                case UnitType.Pixel:
                {
                    return "px";
                }
                case UnitType.Point:
                {
                    return "pt";
                }
                case UnitType.Pica:
                {
                    return "pc";
                }
                case UnitType.Inch:
                {
                    return "in";
                }
                case UnitType.Mm:
                {
                    return "mm";
                }
                case UnitType.Cm:
                {
                    return "cm";
                }
                case UnitType.Percentage:
                {
                    return "%";
                }
                case UnitType.Em:
                {
                    return "em";
                }
                case UnitType.Ex:
                {
                    return "ex";
                }
            }
            return string.Empty;
        }
        private static UnitType GetTypeFromString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return UnitType.Pixel;
            }
            if (value.Equals("px"))
            {
                return UnitType.Pixel;
            }
            if (value.Equals("pt"))
            {
                return UnitType.Point;
            }
            if (value.Equals("%"))
            {
                return UnitType.Percentage;
            }
            if (value.Equals("pc"))
            {
                return UnitType.Pica;
            }
            if (value.Equals("in"))
            {
                return UnitType.Inch;
            }
            if (value.Equals("mm"))
            {
                return UnitType.Mm;
            }
            if (value.Equals("cm"))
            {
                return UnitType.Cm;
            }
            if (value.Equals("em"))
            {
                return UnitType.Em;
            }
            if (!value.Equals("ex"))
            {
                throw new ArgumentOutOfRangeException("value");
            }
            return UnitType.Ex;
        }
        public static bool operator ==(Unit left, Unit right)
        {
            if (left.type != right.type)
            {
                return false;
            }
            return left.@value == right.@value;
        }
        public static implicit operator Unit(int n)
        {
            return Unit.Pixel(n);
        }
        public static bool operator !=(Unit left, Unit right)
        {
            if (left.type != right.type)
            {
                return true;
            }
            return left.@value != right.@value;
        }
        public static Unit Parse(string s)
        {
            return new Unit(s, CultureInfo.CurrentCulture);
        }
        public static Unit Parse(string s, CultureInfo culture)
        {
            return new Unit(s, culture);
        }
        public static Unit Percentage(double n)
        {
            return new Unit(n, UnitType.Percentage);
        }
        public static Unit Pixel(int n)
        {
            return new Unit(n);
        }
        public static Unit Point(int n)
        {
            return new Unit((double)n, UnitType.Point);
        }
        public override string ToString()
        {
            return this.ToString((IFormatProvider)CultureInfo.CurrentCulture);
        }
        public string ToString(CultureInfo culture)
        {
            return this.ToString((IFormatProvider)culture);
        }
        public string ToString(IFormatProvider formatProvider)
        {
            string str;
            if (this.IsEmpty)
            {
                return string.Empty;
            }
            str = (this.type != UnitType.Pixel ? ((float)this.@value).ToString(formatProvider) : ((int)this.@value).ToString(formatProvider));
            return string.Concat(str, Unit.GetStringFromType(this.type));
        }
    }
