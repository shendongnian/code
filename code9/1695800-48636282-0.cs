    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Lines")
        {
            Vector3 linePos = col.transform.position;
            float linePosX = col.transform.position.x;
    
            Debug.Log("Collision with line");
            LockPostion(linePosX);
        }
    }
