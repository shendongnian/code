    void Update () {
        // Assume that Offset's value is { 2, 3 }
        Offset = new Vector2 (0, Time.deltaTime * speed);
        // Assume Time.DeltaTime's value is 0.12f
        // Assume speed's value is 10
        // Now to figure out the problem ( 0.12f * 10f = 1.2f )
        // Offset's value is now 1.2f
        GetComponent<Renderer> ().material.mainTextureOffset = Offset;
    }
