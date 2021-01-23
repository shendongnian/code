    public ParticleSystem particleSystem;
    
    void Start()
    {
        //Create Gradient key
        GradientColorKey[] gradientColorKey;
        gradientColorKey = new GradientColorKey[3];
        gradientColorKey[0].color = Color.red;
        gradientColorKey[0].time = 0f;
        gradientColorKey[1].color = Color.blue;
        gradientColorKey[1].time = 0.5f;
        gradientColorKey[2].color = Color.green;
        gradientColorKey[2].time = 1f;
    
        //Create Gradient alpha
        GradientAlphaKey[] gradientAlphaKey;
        gradientAlphaKey = new GradientAlphaKey[3];
        gradientAlphaKey[0].alpha = 1.0f;
        gradientAlphaKey[0].time = 0.0f;
        gradientAlphaKey[1].alpha = 0.5f;
        gradientAlphaKey[1].time = 0.5f;
        gradientAlphaKey[2].alpha = 1f;
        gradientAlphaKey[2].time = 1f;
    
        //Create Gradient
        Gradient gradient = new Gradient();
        gradient.SetKeys(gradientColorKey, gradientAlphaKey);
    
        //Create Color from Gradient
        ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient();
        color.mode = ParticleSystemGradientMode.Gradient;
        color.gradient = gradient;
    
        //Assign the color to particle
        ParticleSystem.MainModule main = particleSystem.main;
        main.startColor = color;
    }
