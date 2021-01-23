    public ParticleSystem.MinMaxCurve rate
    {
        get
        {
            ParticleSystem.MinMaxCurve curve = new ParticleSystem.MinMaxCurve();
            getParticleRate(this.tempParticleSystem, ref curve);
            return curve;
        }
        set
        {
            setParticleRate(this.tempParticleSystem, ref value);
        }
    }
