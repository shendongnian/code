    private ParticleSystem trailPartical; 
    public Color StartColor
    {
        set
        {
            var main = trailPartical.main;
            main.startColor = value;
        }
    }
