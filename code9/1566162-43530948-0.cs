    GameObject player;
    void Update () {
        if (Input.GetKeyDown(KeyCode.W)) {
            _playerPosition.y += 5f; 
        }
    
        if (Input.GetKeyDown(KeyCode.S)) {
            _playerPosition.y -= 5f;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
        _playerPosition.x += 5f;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            _playerPosition.x -= 5f;
        }
        player.transform.position = _playerPosition;
    }
