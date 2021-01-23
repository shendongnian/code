    public static IEnumerator MoveObject(Transform objectToMove, Vector3 targetPosition, float moveSpeed, System.Action<bool> callBack)
    {
        float currentProgress = 0;
        Vector3 cashedObjectPosition = objectToMove.transform.position;
        while (currentProgress <= 1)
        {
            currentProgress += moveSpeed * Time.deltaTime;
            objectToMove.position = Vector3.Lerp(cashedObjectPosition, targetPosition, currentProgress);
            yield return null;
            if (currentProgress >= 1)
                callBack(true);
        }
    }
