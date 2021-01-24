        public static T GetObject<T>() where T: Father
        {
            var firstSon = new FirstSon();
            var secondSon = new SecondSon();
            if (firstSon.GetType() == typeof(T))
                return (T)Convert.ChangeType(firstSon, typeof(T));
            return (T)Convert.ChangeType(secondSon, typeof(T));
        }
