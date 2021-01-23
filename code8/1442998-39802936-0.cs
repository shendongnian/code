    try
    {
       var result = recognizer.Predict(image);
    }
    catch (System.AccessViolationException)
    {
       recognier =  new EigenFaceRecognizer(80, double.PositiveInfinity);
    }
