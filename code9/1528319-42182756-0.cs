    public GameObject SphereParticleCollider;
    
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> neighbouringParticles = new List<ParticleSystem.Particle>();
    ParticleSystem mainParticle;
    
    private void Start()
    {
        mainParticle = GetComponent<ParticleSystem>();
    }
    
    void OnParticleTrigger()
    {
        //Get particles that entered 
        findEnteredParticles();
    
        //Get neighbouring particles 
        findNeighbouringParticles();
    }
    
    void findEnteredParticles()
    {
        if (mainParticle == null)
        {
            mainParticle = GetComponent<ParticleSystem>();
        }
        ParticlePhysicsExtensions.GetTriggerParticles(mainParticle, ParticleSystemTriggerEventType.Enter, enter);
    }
    
    void findNeighbouringParticles()
    {
        //Get default Spehere Collider position
        Vector3 currentParticleCollider = SphereParticleCollider.transform.position;
    
        //Find particles that are Neighbour of each particle that entererd
        for (int i = 0; i < enter.Count; i++)
        {
            //Move Spehere Collider to the positon of each particle that enetered
            SphereParticleCollider.transform.position = enter[i].position;
    
            //Finally get all particles that are inside the Sphere. These are considered to be near the particle
            ParticlePhysicsExtensions.GetTriggerParticles(mainParticle, ParticleSystemTriggerEventType.Inside, neighbouringParticles);
    
            //Loop through and do something with each neighbouring particles 
            for (int j = 0; j < neighbouringParticles.Count; j++)
            {
                ParticleSystem.Particle neighbourParticles = neighbouringParticles[j];
                //.....
                //......
                //.....
                Debug.Log("Found neighbouring particles!");
            }
        }
    
        //Reset the position of the Spehere Collider position
        SphereParticleCollider.transform.position = currentParticleCollider;
    }
