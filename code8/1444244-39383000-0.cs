    public GameObject GameObjectToShake;
    bool shaking = false;
    IEnumerator shakeGameObjectCOR(GameObject objectToShake, float totalShakeDuration, float decreasePoint)
    {
        //Get Original Pos and rot
        Transform objTransform = objectToShake.transform;
        Vector3 defaultPos = objTransform.position;
        Quaternion defaultRot = objTransform.rotation;
        float counter = 0f;
        //Shake Speed
        const float speed = 0.1f;
        //Angle Rotation(Optional)
        const float angleRot = 15;
        //Do the actual shaking
        while (counter < totalShakeDuration)
        {
            counter += Time.deltaTime;
            float tempSpeed = speed;
            float tempAngle = angleRot;
            //Shake GameObject
            objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * tempSpeed;
            objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(1f, 1f, 1f));
            yield return null;
            //Check if we have reached the decreasePoint then start decreasing  tempSpeed value
            if (counter >= decreasePoint)
            {
                Debug.Log("Decreasing shake");
                //Reset counter to 0 
                counter = 0f;
                while (counter < decreasePoint)
                {
                    counter += Time.deltaTime;
                    tempSpeed = Mathf.Lerp(speed, 0, counter / decreasePoint);
                    tempAngle = Mathf.Lerp(angleRot, 0, counter / decreasePoint);
                    Debug.Log("Decrease Value: " + tempSpeed);
                    //Shake GameObject
                    objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * tempSpeed;
                    objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(1f, 1f, 1f));
                    yield return null;
                }
                //Break from the  outside loop
                break;
            }
        }
        objTransform.position = defaultPos; //Reset to original postion
        objTransform.rotation = defaultRot;
        shaking = false; //So that we can call this function next time
        Debug.Log("Done!");
    }
    void shakeGameObject(GameObject objectToShake, float shakeDuration, float decreasePoint)
    {
        if (shaking)
        {
            return;
        }
        shaking = true;
        StartCoroutine(shakeGameObjectCOR(objectToShake, shakeDuration, decreasePoint));
    }
    void Start()
    {
        shakeGameObject(GameObjectToShake, 5, 4f);
    }
