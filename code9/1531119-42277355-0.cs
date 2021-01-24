    if (GestureManager.Instance.IsNavigating &&
        HandsManager.Instance.FocusedGameObject == gameObject)
    {
        //speed and navigiation of rotation
        float rotationFactor = ManipulationManager.Instance.ManipulationPosition.y * RotationSensitivity;
    
        Debug.Log(totransform.eulerAngles);
        if (totransform.eulerAngles.x < 100) {
            totransform.Rotate(new Vector3(rotationFactor, 0, 0));
        }
    }
