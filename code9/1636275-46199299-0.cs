     private void MoveToCollectable()
        {
            Collectable collectable = collectablesToCollect.First();
            StartCoroutine(CollectionMovement(collectable)); // collect it
        }
    
        private IEnumerator CollectionMovement(Collectable collectable)
        {
            if (isCollecting)
                yield break; // Already in use? return
    
            isCollecting = true;
    
            yield return StartCoroutine(MoveToPoint(collectable.GetCollectablePosition())); // Move to it
    
            if (collectable != null)
                collectable.StartMovingToPlayer(); // make it move to the player
    
            yield return StartCoroutine(MoveToPoint(currentPosition)); // move back
    
            collectablesToCollect.Remove(collectable); // remove it from the list
    
            if (CollectablesInRange()) // any other collectables in range?
                MoveToCollectable(); // do it again
    
            isCollecting = false;
        }
    
        private IEnumerator MoveToPoint(Vector3 targetPosition) // move to a point
        {
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }
        }
