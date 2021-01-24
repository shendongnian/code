        Class SphereMover :MonoBehaviour
        {
            public GameObject target;
            void Update(){
                   if(target !=null){
                       transform.position = Vector3.MoveTowards(transform.position, target, 1 * Time.deltaTime);
        }
        }
    
    }
