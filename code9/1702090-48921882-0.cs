    void Generate(double previousPositionOnCircleInRadian, double speed,
        double amplitude, out double sinValueMultiliedByAmplitude, 
        out double nextPositionOnCircleInRadian)
    {
        nextPositionOnCircleInRadian = previousPositionOnCircleInRadian + Time.deltaTime*speed;
        sinValueMultiliedByAmplitude = amplitude * Math.Sin(nextPositionOnCircleInRadian);
    }
