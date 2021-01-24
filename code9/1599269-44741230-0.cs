    List<object> actuallyDoubles = new List<object>{ 1.0, 2.0, 3.0 };
    List<double> doubleDirect = actuallyDoubles.ConvertAll(x => (double)x); // works
    // List<float> floatDirect = actuallyDoubles.ConvertAll(x => (float)x); // fails per question
    List<float> floatViaDouble = actuallyDoubles.ConvertAll(x => (float)(double)x); // works
    List<float> floatViaConvert = actuallyDoubles.ConvertAll(x => Convert.ToSingle(x)); // works
