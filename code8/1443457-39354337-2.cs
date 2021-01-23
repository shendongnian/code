    static class Utils
    {
        public static void checkIfNull(object obj)
        {
            if (obj == null) throw new MyException();
        }
    }
