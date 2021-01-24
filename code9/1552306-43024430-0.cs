    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("returning to checkpoint");
            tf.position = Checkpoint.spawnPoint.position;
        }
    }
