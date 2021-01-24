    bool triggerEntered = false;
    
    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "storm")
        {
            triggerEntered = true;
    
            while (triggerEntered)
            {
                playerVitals.healthSlider.value -= value;
                yield return new WaitForSeconds(1);
            }
        }
    }
    IEnumerator OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "storm")
        {
            triggerEntered = false;
        }
    }
