        public static bool IsNull_exception(dynamic source)
        {
            var h = source.x;
            Console.WriteLine(object.ReferenceEquals(null, h));
            Console.WriteLine(null == h);
            Console.WriteLine(h == null);
            if (source.x?.y == null) return true;
            return false;
        }
