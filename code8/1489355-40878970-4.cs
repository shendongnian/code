    public static double[] ComputeQuadraticValues(double startX, double increments, int numberOfIntervals, double a, double b, double c)
    {
    	//We need numberOfInterval + 1 values
        double[] yPoints = new double[numberOfIntervals+1];
    	
        for (int index = 0; index <= numberOfIntervals; index++, startX += increments)
        {
    		//evaluate the function and get the y value for this x
            yPoints[index] = EvaluateQuadraticValue(startX, a, b, c);
    		//Console.WriteLine("({0}, {1})", startX, yPoints[index]);
        }
        
    	return yPoints;
    }
