        public static void Delete(int a)
		{	
			int resizedArrayLength = array.Length - 1;
			while(a < resizedArrayLength)
			{
				array[a] = array[a + 1];
				a++;
			}
			Array.Resize(ref array, resizedArrayLength); // this will resize your array to specified length.
		}
