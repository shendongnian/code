    ParticleSystem m_System = GetComponent<ParticleSystem>();
    ParticleSystem.MainModule main = m_System.main;
    
    ParticleSystem.MinMaxCurve minMaxCurve = main.startLifetime;
    
    if (minMaxCurve.mode == ParticleSystemCurveMode.Constant)
    {
        m_OriginalLifetime = m_System.main.startLifetime.constant;
    }
    else if (minMaxCurve.mode == ParticleSystemCurveMode.Curve)
    {
        AnimationCurve animCurveLifetime = m_System.main.startLifetime.curve;
    }
    ...
