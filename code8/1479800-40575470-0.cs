    bool isMoving = false;
    void Update()
    {
        transform.Translate(Vector3.forward * ForwardSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A) && side > maxSideLeft)
        {
            MoveObjectTo(this.transform, new Vector3(this.transform.position.x - 12, this.transform.position.y, this.transform.position.z + 10), movementSpeed);
            side -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.D) && side < maxSideRight)
        {
            MoveObjectTo(this.transform, new Vector3(this.transform.position.x + 12, this.transform.position.y, this.transform.position.z + 10), movementSpeed);
            side += 1;
        }
        if (Input.GetKeyDown(KeyCode.W) && level < maxLevelHeight)
        {
            MoveObjectTo(this.transform, new Vector3(this.transform.position.x, this.transform.position.y + 12, this.transform.position.z + 10), movementSpeed);
            level += 1;
        }
        else if (Input.GetKeyDown(KeyCode.S) && level > minLevelHeight)
        {
            MoveObjectTo(this.transform, new Vector3(this.transform.position.x, this.transform.position.y - 12, this.transform.position.z + 10), movementSpeed);
            level -= 1;
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Scene1");
            Time.timeScale = 1;
        }
    }
    private void MoveObjectTo(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        //Don't do anything Object is already moving
        if (isMoving)
        {
            return;
        }
        //If not moving set isMoving to true
        isMoving = true;
        StartCoroutine(MoveObject(objectToMove, targetPosition, moveSpeed));
    }
    public IEnumerator MoveObject(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        float currentProgress = 0;
        Vector3 cashedObjectPosition = objectToMove.transform.position;
        while (currentProgress <= 1)
        {
            currentProgress += moveSpeed * Time.deltaTime;
            objectToMove.position = Vector3.Lerp(cashedObjectPosition, targetPosition, currentProgress);
            yield return null;
        }
        //Done moving. Set isMoving to false
        isMoving = false;
    }
