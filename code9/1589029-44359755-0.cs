    private IEnumerator SmoothMovement(List<Node> path)
    {
        float step = speed * Time.deltaTime;
    
        for (int i = 0; i < path.Count; i++)
        {
            targetPosition = new Vector3(path[i].coordinatesX, path[i].coordinatesY, 0f);
    
            float sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;
    
            while (sqrRemainingDistance > float.Epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
                sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;
                yield return null;
            }
    
            position = transform.position;
        }
        //Next Step
    }
