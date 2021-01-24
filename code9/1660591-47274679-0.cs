    //signal + noise
    double fs = 1000; //sampling rate
    double fw = 5; //signal frequency
    double n = 5; //number of periods to show
    double A = 10; //signal amplitude
    double N = 2; //noise amplitude
    int size = (int)(n * fs / fw); //sample size
    var t = Enumerable.Range(1, size).Select(p => p * 1 / fs).ToArray();
    var noise = new WhiteGaussianNoiseSource();
    var y = t.Select(p => (A * Math.Sin(2 * pi * fw * p)) + (N * noise.ReadNextSample())).ToArray();
    //filter
    double fc = 10; //cutoff frequency
    var filter = OnlineFirFilter.CreateLowpass(ImpulseResponse.Finite, fs, fc);
    double[] yf1 = filter.ProcessSamples(y); //Lowpass
    double[] yf2 = filter.ProcessSamples(yf1.Reverse().ToArray()); //Lowpass reversed
    double[] yf2r = yf2.Reverse().ToArray(); //Zero-Phase
