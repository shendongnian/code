    private Vector3 ballPosition;
    public bool spawnNewBall;
    void Start() {
        spawnNewBall = true;
    }
    
    void OnTriggerEnter2D (Collider2D other) {
    
        if (other.gameObject.tag == "Ball") {
    
            if (spawnNewBall) {
                other.GetComponent</*YourScriptName*/>().spawnNewBall = false;
            }
    
            ballPosition = new Vector3 ((transform.position.x + other.transform.position.x) / 2, (transform.position.y + other.transform.position.y) / 2, 0.0f);
            StartCoroutine ("RespawnBall");
        }
    }
    
    IEnumerator RespawnBall () {
        if (spawnNewBall) {
            Instantiate (gameObject, ballPosition, Quaternion.identity);
        }
        Destroy (gameObject);
        yield return null;
    }
