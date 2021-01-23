        private static string ConvertArrayToBase64<T>(T[] array)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                var byteArray = new byte[array.Length * System.Runtime.InteropServices.Marshal.SizeOf<T>()];
                Buffer.BlockCopy(array, 0, byteArray, 0, byteArray.Length);
                return Convert.ToBase64String(byteArray);
            }
            throw new InvalidOperationException("Generic type must be int[] or long[].");
        }
        private static T[] ConvertBase64ToArray<T>(string base64String)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                var byteArray = Convert.FromBase64String(base64String);
                var array = new T[byteArray.Length / System.Runtime.InteropServices.Marshal.SizeOf<T>()];
                Buffer.BlockCopy(byteArray, 0, array, 0, byteArray.Length);
                return array;
            }
            throw new InvalidOperationException("Generic type must be int or long.");
        }
