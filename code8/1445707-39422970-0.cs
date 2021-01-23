    // using System.Linq;
    var array1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    var array2 = new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    var array3 = new[] { 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    var array4 = new[] { 4, 5, 6, 7, 8, 9, 10, 11, 12 };
    var result = array1.Intersect(array2).Intersect(array3).Intersect(array4);
    Console.WriteLine(string.Join(", ", result));
