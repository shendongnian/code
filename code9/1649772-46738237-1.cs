    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // cast a ray at the mouses position into the screen and get information of the object the ray passes through
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "child") //each child object is tagged as "child"
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
