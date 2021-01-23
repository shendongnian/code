     public float myAngle = 0 ;
    public void LookRotation(Transform character, Transform camera)
    {
        float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
        float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
        // Add your angle here
        m_CharacterTargetRot *= Quaternion.Euler (0f, yRot + myAngle, 0f);
        m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
        if(clampVerticalRotation)
            m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);
        if(smooth)
        {
            character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
                smoothTime * Time.deltaTime);
            camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                smoothTime * Time.deltaTime);
        }
        else
        {
            character.localRotation = m_CharacterTargetRot; // move y axe
            camera.localRotation = m_CameraTargetRot;       // move x axe
        }
    }
