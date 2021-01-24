    GameObject otherController;
    if(VRTK_DeviceFinder.IsControllerLeftHand(grabbingObject)
    {
      otherController = VRTK_DeviceFinder.GetControllerRightHand();
    }
    else
    {
      otherController = VRTK_DeviceFinder.GetControllerLeftHand();
    }
