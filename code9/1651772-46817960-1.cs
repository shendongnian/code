    public static class ExtMethods{
        public static void SetValue<T>(this T[] arr, T value) {
            if (arr != null) {
                for (int i = 0; i < arr.Length; i++) {
                     arr[i] = value;
                }
            } 
        }
    }
