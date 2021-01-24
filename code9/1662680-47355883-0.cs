    private EnemyAI myEnemy;
    void Start()
    {
        RegisterForMouseEvents();
    }
    private void RegisterForMouseEvents()
    {
        var cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        cameraRaycaster.onMouseOverEnemy += OnMouseOverEnemy;
    }
    void OnMouseOverEnemy(EnemyAI enemy)
    {
        myEnemy = enemy;
    }
    void Update(){
        //log position
        print(myEnemy.transform.position);
    }
