    PIVRSystem = ^IVRSystem;
    IVRSystem = packed record
        GetRecommendedRenderTargetSize : _GetRecommendedRenderTargetSize;
        GetProjectionMatrix : _GetProjectionMatrix;
        ....
        AcknowledgeQuit_UserPrompt : _AcknowledgeQuit_UserPrompt;
    end;
