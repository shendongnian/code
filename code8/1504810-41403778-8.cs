    //Create Color from Gradient
    ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient();
    color.mode = ParticleSystemGradientMode.TwoColors;
    color.colorMin = Color.red;
    color.colorMax = Color.green;
    
    //Assign the color to the particle
    ParticleSystem.MainModule main = particleSystem.main;
    main.startColor = color;
