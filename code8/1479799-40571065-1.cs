    private void MoveObjectTo(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        if (canCallCoroutine)
        {
            canCallCoroutine = false;
            StartCoroutine(MoveObject(objectToMove, targetPosition, moveSpeed, finished =>
                {
                    if (finished != null)
                    {
                        if (finished)
                            canCallCoroutine = true;
                    }
                }));
        }
    }
