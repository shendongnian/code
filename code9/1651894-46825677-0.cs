    public static class DBSetExtensions {
        public static void Setup<T>(this DbSet<T> list, Action<T> lamda){
            lamda(objectFromDbSet);
        }
    }
