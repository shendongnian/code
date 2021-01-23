        public static long ToJulian(string mdy)
        {
            var split = mdy.Split('/');
            return ToJulian(int.Parse(split[2]), int.Parse(split[0]), int.Parse(split[1]));
        }
