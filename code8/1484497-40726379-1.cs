    public Collider2D[] myBoxColliders = null;
    List<KeyValuePair<Collider2D, Collider2D>> usedCollider = new List<KeyValuePair<Collider2D, Collider2D>>();
    void checkArrayCollision()
    {
        for (int i = 0; i < myBoxColliders.Length; i++)
        {
            checkCollision(i, ref usedCollider);
        }
        //Reset List for next function call
        usedCollider.Clear();
    }
    void checkCollision(int currentIndex, ref List<KeyValuePair<Collider2D, Collider2D>> usedCollider)
    {
        for (int i = 0; i < myBoxColliders.Length; i++)
        {
            //Make sure that this two Colliders are not the-same
            if (myBoxColliders[currentIndex] != myBoxColliders[i])
            {
                //Now, make sure we have not checked between this 2 Objects
                if (!checkedBefore(usedCollider, myBoxColliders[currentIndex], myBoxColliders[i]))
                {
                    if (myBoxColliders[currentIndex].IsTouching(myBoxColliders[i]))
                    {
                        //FINALLY, COLLISION IS DETECTED HERE, call ArrayCollisionDetection
                        ArrayCollisionDetection(myBoxColliders[currentIndex], myBoxColliders[i]);
                    }
                    //Mark it checked now
                    usedCollider.Add(new KeyValuePair<Collider2D, Collider2D>(myBoxColliders[currentIndex], myBoxColliders[i]));
                }
            }
        }
    }
    bool checkedBefore(List<KeyValuePair<Collider2D, Collider2D>> usedCollider, Collider2D col1, Collider2D col2)
    {
        bool checkedBefore = false;
        for (int i = 0; i < usedCollider.Count; i++)
        {
            //Check if key and value exist and vice versa
            if ((usedCollider[i].Key == col1 && usedCollider[i].Value == col2) ||
                    (usedCollider[i].Key == col2 && usedCollider[i].Value == col1))
            {
                checkedBefore = true;
                break;
            }
        }
        return checkedBefore;
    }
    void ArrayCollisionDetection(Collider2D col1, Collider2D col2)
    {
        Debug.Log(col1.name + " is Touching " + col2.name);
    }
