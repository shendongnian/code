    bool triggerEntered = false;
    
    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "storm")
        {
            triggerEntered = true;
    
            //Decrease while triggerEntered is true
            while (triggerEntered)
            {
                playerVitals.healthSlider.value -= value;
                yield return new WaitForSeconds(1);
    
                //Exit if we hit the min value?
                if (playerVitals.healthSlider.value <= 0)
                {
                    yield break;
                }
            }
        }
    }
    
    IEnumerator OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "storm")
        {
            triggerEntered = false;
    
            //Increase while triggerEntered is false
            while (!triggerEntered)
            {
                playerVitals.healthSlider.value += value;
                yield return new WaitForSeconds(1);
    
                //Exit if we hit the max value?
                if (playerVitals.healthSlider.value >= 100)
                {
                    yield break;
                }
            }
    
        }
    }
