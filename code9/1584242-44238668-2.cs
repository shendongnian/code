    void Update()
    {
        if (throwTimer > 0)
        {
            throwTimer -= Time.deltaTime;
            Debug.Log("Timer at: " + throwTimer);
        }
        // Using a single touch as control - Letholor
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
            Debug.Log("You are touching at position: " + touchPos);
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hitResult;
            Physics.Raycast(ray, out hitResult);
            Vector3 throwDestination = hitResult.point;
            Debug.Log("Throw destination is " + throwDestination);
            Throw(throwDestination);
        }
    }
    public void Throw(Vector3 throwDestination) {
        if (throwTimer > 0)
        {
            Debug.Log("Cooling down.");
            return;
        }
        throwTimer = throwResetTimer;
        Debug.Log("Throwing to " + throwDestination);
        Instantiate(projectile, throwOrigin.position, throwOrigin.rotation);
    }
