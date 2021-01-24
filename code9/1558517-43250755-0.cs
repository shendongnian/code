    public GameObject radiationEffect;
    public EntityVitals Vitals { get { return m_Vitals; } }
    private EntityVitals m_Vitals;
    // Declare a list that will contain the players.
    List<GameObject> playersInArea = new List<GameObject>();
    // Use this for initialization
    void Start() {
        InvokeRepeating ("DamagePlayers", 1.5f, 3.5f);
    }
    void DamagePlayers() {
         foreach (var player in playersInArea) {
             var entity = player.GetComponent<EntityEventHandler>();
             if(entity)
             {
                 var healthEventData = new HealthEventData(-Random.Range(7.0f, 23.0f));
                 entity.ChangeHealth.Try(healthEventData);
             }
         }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playersInArea.Add(other.gameObject);
            radiationEffect.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playersInArea.Remove(other.gameObject);
            if (playersInArea.Count == 0) {
                radiationEffect.SetActive(false);
            }
        }
    }
