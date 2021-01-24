    //NavMeshAgent
    private NavMeshAgent agent;
    //Target Transform
    public Transform trans;
    void Start()
    {
        //Get the component
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        SetDestination(trans.position);
    }
    void SetDestination (Vector3 des)
    {
        //Set the destination
        agent.SetDestination(des);
    }
