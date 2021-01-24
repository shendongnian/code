    Vector3 prevPos;
    public void update(){
        if(prevPos == transform.position){
            Debug.Log("Object Moving");
        }
        prevPos = transform.position;
    }
