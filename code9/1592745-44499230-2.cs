    public float Damage { get; set; }
    public float Seconds { get; set; }
    public float Delay { get; set; }
    public float ApplyDamageNTimes { get; set; }
    public float ApplyEveryNSeconds { get; set; }
    private int appliedTimes = 0;
    
    void Start() {
        StartCoroutine(Dps());
    }
    
    IEnumerator Dps() {
        yield return new WaitForSeconds(Delay);
        while(appliedTimes < ApplyDamageNTimes)
        {
            damageable.TakeDamage(damage);
            yield return new WaitForSeconds(ApplyEveryNSeconds);
            appliedTimes++;
        }
        Destroy(this);
    }
