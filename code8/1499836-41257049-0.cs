    public GameObject seedlings;
    public GameObject player;
    Vector3 mousePOS = Input.mousePosition;
    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            PlantInGround();
        }
    }
    void PlantInGround()
    {
        Vector3 mousePOS = Input.mousePosition;
        mousePOS.z = +12;
        mousePOS = Camera.main.ScreenToWorldPoint(mousePOS);
        if (((player.transform.position.y < mousePOS.y + 0.5) && (player.transform.position.y > mousePOS.y - 1.5)) && ((player.transform.position.x < mousePOS.x + 1) && (player.transform.position.x > mousePOS.x - 1)))
        {
            Instantiate(seedlings, mousePOS, Quaternion.identity);
         
        }
    }
}
