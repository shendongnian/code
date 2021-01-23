            var longArray = new long[] { 11111, 22222, 33333, 44444 };
            var intArray = new int[] { 55555, 66666, 77777, 88888};
            string base64longs = ConvertArrayToBase64(longArray);
            Console.WriteLine(base64longs);
            Console.WriteLine(string.Join(", ", ConvertBase64ToArray<long>(base64longs)));
            string base64ints = ConvertArrayToBase64(intArray);
            Console.WriteLine(base64ints);
            Console.WriteLine(string.Join(", ", ConvertBase64ToArray<int>(base64ints)));
