     using System.Linq;
     ...
     int[] arr = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
     int[] head = arr.Take(5).ToArray();
     int[] tail = arr.Skip(5).ToArray();
