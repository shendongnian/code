    GameObject gun;
    
    void Start()
    {
        /*
            initialization code for gun GameObject
        */
    }
    void Update()
    {
        Vector3 gunScreenPosition = Camera.main.WorldToScreenPoint(gun.transform.position);
        Vector3 mouseDirection = Input.mousePosition - gunScreenPosition;
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
