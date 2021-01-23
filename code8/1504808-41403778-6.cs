    //Create Color
    ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient();
    color.mode = ParticleSystemGradientMode.Color;
    color.color = Color.red;
    
    //Assign the color to your particle
    ParticleSystem.MainModule main = trailPartical.main;
    main.startColor = color;
