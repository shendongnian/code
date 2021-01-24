    [SerializeField]
    private float speed;
    [SerializeField]
    private float movementTriggerWidth;
    private Vector3 movementDirection;
    private bool move = false;
    private GameObject player;
    private float triggerDistance;
    private void Start()
    {
        player = Globals.GetPlayerObject();
        triggerDistance = transform.localScale.x / 2 - movementTriggerWidth;
    }
    private void OnTriggerEnter(Collider col)
    {
        col.transform.parent = transform;
    }
    private void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject == player)
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 platformPosition = transform.position;
            if (Vector3.Distance(playerPosition, platformPosition) > triggerDistance)
            {
                movementDirection = playerPosition - platformPosition;
                move = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (move)
            transform.Translate(movementDirection * speed * Time.deltaTime);
        move = false;
    }
