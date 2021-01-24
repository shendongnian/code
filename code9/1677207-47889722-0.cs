    Vector2 lastTouch;
    
    void Update()
    {
      if (GvrController.TouchDown) {
       lastTouch = GvrController.TouchPos;
      }
      if(!GvrController.IsTouching){
       Vector2 swipeDirection = GvrController.TouchPos - lastTouch;
      }
    }
    
