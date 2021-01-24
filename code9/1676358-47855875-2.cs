      public ParticleSystem.MinMaxGradient startColor
      {
        set
        {
          ParticleSystem.MainModule.SetStartColor(this.m_ParticleSystem, ref value);
        }
        get
        {
          ParticleSystem.MinMaxGradient gradient = new ParticleSystem.MinMaxGradient();
          ParticleSystem.MainModule.GetStartColor(this.m_ParticleSystem, ref gradient);
          return gradient;
        }
      }
