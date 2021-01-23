    Try this Out.  
    I hope this helps.
 
 
    void Update(){
    if (Input.GetMouseButtonDown(0)){
        startPosition = Input.mousePosition;
    }
    if (Input.GetMouseButtonUp(0)){
        float swipe = startPosition.x - Input.mousePosition.x;
    }
      
   
            if (swipe < 0)
            {
                print("LTR");
            } else{
                print("RTL");
            }
        }
        
    }
    }
