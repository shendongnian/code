        private static string ConvertArrayToBase64<T>(IList<T> array) where T : struct
        {
            if (typeof(T).IsPrimitive)
            {
                int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
                var byteArray = new byte[array.Count * size];
                Buffer.BlockCopy((Array)array, 0, byteArray, 0, byteArray.Length);
                return Convert.ToBase64String(byteArray);
            }
            throw new InvalidOperationException("Only primitive types are supported.");
        }
        private static T[] ConvertBase64ToArray<T>(string base64String) where T : struct
        {
            if (typeof(T).IsPrimitive)
            {
                var byteArray = Convert.FromBase64String(base64String);
                var array = new T[byteArray.Length / System.Runtime.InteropServices.Marshal.SizeOf(typeof(T))];
                Buffer.BlockCopy(byteArray, 0, array, 0, byteArray.Length);
                return array;
            }
            throw new InvalidOperationException("Only primitive types are supported.");
        }
