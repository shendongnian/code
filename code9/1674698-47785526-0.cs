    double[] doubleArray = new double[] { 1, 2, 3, 4, 5 };
    List<double[]> doubleArrayList = new List<double[]> { doubleArray };
    List<List<double[]>> MyList = new List<List<double[]>> { doubleArrayList };
    var singleItem = MyList[0][0][0];
    Console.WriteLine(singleItem);
