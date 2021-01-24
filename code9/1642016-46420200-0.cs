    private IEnumerator ChangeIntensity()
    {
        while (true)
        {
            pointLight.intensity += isIncreasing ? luminositySteps : -luminositySteps;
    
            if (pointLight.intensity <= minLuminosity)
                isIncreasing = true;
    
            if (pointLight.intensity >= maxLuminosity)
            {
                isIncreasing = false;
                yield return new WaitForSeconds(shineDuration);
            }
            yield return null;
        }
    }
