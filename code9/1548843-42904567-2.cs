    public class CuteInterfaceImplementation_HELPER
    {
        public static IMyCuteInterface<T> From<T>(T t)
        {
            if (t is IEnumerable)
            {
                dynamic dyn = t;
                return FromEnumerable(dyn);
            }
            else
            {
                return new CuteInterfaceImplementation<T>(t);
            }
        }
        public static IMyCuteInterface<T> FromEnumerable<T>(T t) where T: IEnumerable
        {
            return new CuteInterfaceImplementation_WITHEnumerable<T>(t);
        }
    }
