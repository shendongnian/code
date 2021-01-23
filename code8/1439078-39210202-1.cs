    public static class CarPartsLibary
    {
        public static string factoryId = "fgk4548j4t5jig3";
        public static string engineId = "fgfgj34lk45l3lj";
        public static string bodyId = "45kjgiu590dkjr";
        public static bool typeCar = true;
        public static bool autoStart = true;
        public static bool allWheelDrive = true;
        public static bool dieselEngine = false;
    }
    var car = CarPartsLibary.typeCar;
    var factory = GetLocation(CarPartsLibary.factoryId);
