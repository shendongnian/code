    // Change the datatype
    public ParticleSystem LeafStormParticleSystem;
    // [...]
    // To modify members later, you can do as you're currently doing:
    LeafStormParticleSystem.maxParticles = 500;
    // Modifying the emission rate is a bit less straightforward, because emission is a struct
    var newEmission = LeafStormParticleSystem.emission;
    newEmission.rate = 5.0f;
    LeafStormParticleSystem.emission = newEmission;
    
