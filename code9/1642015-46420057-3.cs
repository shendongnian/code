    private IEnumerator ChangeIntensity()
    {
        while(true)
        {
            while(pointLight.intensity <= maxLuminosity)
            {
                pointLight.intensity += luminositySteps; // increase the firefly intensity / fade in
                yield return new WaitForEndOfFrame();
            }
    
            yield return new WaitForSeconds(shineDuration); // wait 3 seconds
            while(pointLight.intensity > minLuminosity)
            {
                pointLight.intensity -= luminositySteps;
                yield return new WaitForEndOfFrame();
            }
        }
    }
