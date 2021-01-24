    IEnumerator fadeInAndOut(Light lightToFade, bool fadeIn, float duration)
    {
        float minLuminosity = 0; // min intensity
        float maxLuminosity = 1; // max intensity
    
        float counter = 0f;
    
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
    
        if (fadeIn)
        {
            a = minLuminosity;
            b = maxLuminosity;
        }
        else
        {
            a = maxLuminosity;
            b = minLuminosity;
        }
    
        float currentIntensity = lightToFade.intensity;
    
        while (counter < duration)
        {
            counter += Time.deltaTime;
    
            lightToFade.intensity = Mathf.Lerp(a, b, counter / duration);
    
            yield return null;
        }
    }
