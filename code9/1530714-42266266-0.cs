    ParticleSystem[] ps = GetComponentsInChildren<ParticleSystem>();
    for (int i = 0; i < ps.Length; i++)
    {
        if (ps[i].gameObject.name == "HitParticles")
        {
            hitParticles = ps[i];
        }
        else if (ps[i].gameObject.name == "DeathParticles")
        {
            deathParticles = ps[i];
        }
    }
