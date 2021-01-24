    #region Attributes
    [SerializeField]
    private ParticleSystem particle;
    private ParticleSystem generatedParticle;
    #endregion
    #region MonoBehaviour
    protected void Start()
    {
        generatedParticle = null;
    }
    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EmitFX(particle);
        }
    }
    #endregion
    public void EmitFX(ParticleSystem a_Particle)
    {
        if(!generatedParticle)
        {
            generatedParticle = Instantiate(particle, particlePos, Qauternion.identity);
        }
        generatedParticle.transform.position = ballPos;       
        generatedParticle.Play();
        // You can set a fixed duration here if your particle system is looping
        // (I assumed it was not so I used the duration of the particle system to detect the end of it)
        StartCoroutine(StopFXAfterDelay(generatedParticle.main.duration));
    }
    private IEnumerator StopFXAfterDelay(float a_Delay)
    {
        yield return new WaitForSeconds(a_Delay);
        generatedParticle.Stop();
    }
