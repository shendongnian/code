    void Update () {
    if (Input.GetMouseButtonDown(0)) {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
                                             Vector2.zero);
 
        if(hit.collider != null)
        {
           Instantiate(openTile, 
                       hit.collider.gameObject.transform.position,
                       Quaternion.identity);
        }
    }
