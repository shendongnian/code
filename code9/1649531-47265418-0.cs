        //signal + noise
        double fs = 1000; //sampling rate
        double fw = 5; //signal frequency
        double fn = 50; //noise frequency
        double n = 5; //number of periods to show
        double A = 10; //signal amplitude
        double N = 1; //noise amplitude
        int size = (int)(n * fs / fw); //sample size
        var t = Enumerable.Range(1, size).Select(p => p * 1 / fs).ToArray();
        var y = t.Select(p => (A * Math.Sin(2 * pi * fw * p)) + (N * Math.Sin(2 * pi * fn * p))).ToArray(); //Original
        //lowpass filter
        double fc = 10; //cutoff frequency
        var lowpass = OnlineFirFilter.CreateLowpass(ImpulseResponse.Finite, fs, fc);
        //bandpass filter
        double fc1 = 0; //low cutoff frequency
        double fc2 = 10; //high cutoff frequency
        var bandpass = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, fs, fc1, fc2);
        //narrow bandpass filter
        fc1 = 3; //low cutoff frequency
        fc2 = 7; //high cutoff frequency
        var bandpassnarrow = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, fs, fc1, fc2);
        double[] yf1 = lowpass.ProcessSamples(y); //Lowpass
        double[] yf2 = bandpass.ProcessSamples(y); //Bandpass
        double[] yf3 = bandpassnarrow.ProcessSamples(y); //Bandpass Narrow
