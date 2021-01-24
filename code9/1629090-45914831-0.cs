    private readonly Stopwatch _zeit = new Stopwatch();
    void Update ()
    {
        if (Input.GetKeyDown ("tab"))
        {
            _zeit.Restart();
        }
        if (Input.GetKeyDown ("space")
        {
            print(_zeit.Elapsed);
        }
    }
