    camera.autoFocus(new Camera.AutoFocusCallback() {                   
        @Override
          public void onAutoFocus(boolean success, Camera camera) {
               camera.cancelAutoFocus();
               Parameters params = camera.getParameters();
               if(params.getFocusMode() != Camera.Parameters.FOCUS_MODE_CONTINUOUS_PICTURE){
                    params.setFocusMode(Camera.Parameters.FOCUS_MODE_CONTINUOUS_PICTURE);
                    camera.setParameters(params);
            }
        }
    });
