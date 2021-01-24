    public GameObject smoke;
    
    void Start()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule psmain = ps.main;
        psmain.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    
    
        //Assign that material to the particle renderer
        ps.GetComponent<Renderer>().material = createParticleMaterial();
    }
    
    Material createParticleMaterial()
    {
        //Create Particle Shader
        Shader particleShder = Shader.Find("Particles/Alpha Blended Premultiply");
    
        //Create new Particle Material
        Material particleMat = new Material(particleShder);
    
        Texture particleTexture = null;
    
        //Find the default "Default-Particle" Texture
        foreach (Texture pText in Resources.FindObjectsOfTypeAll<Texture>())
            if (pText.name == "Default-Particle")
                particleTexture = pText;
    
        //Add the particle "Default-Particle" Texture to the material
        particleMat.mainTexture = particleTexture;
    
        return particleMat;
    }
