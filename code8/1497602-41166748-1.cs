    // Determine drop coordinates dynamically       
    Point dropDestinationPoint = controlYouWanttoDropOn.GetClickablePoint();
    // Add some buffer to avoid possible clicking over the edges - Optional
    dropDestinationPoint.X += 5; 
    dropDestinationPoint.Y += 5;    
    Mouse.StartDragging(controlYouWantToDrag);
    Mouse.StopDragging(controlYouWanttoDropOn, dropDestinationPoint);
