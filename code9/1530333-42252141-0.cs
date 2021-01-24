        public static bool IsNotEmpty(object obj)
        {
            var collection = obj as ICollection;
            return collection == null || collection.Count > 0;
        }
