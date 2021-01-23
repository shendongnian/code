    void blink(GameObject obj, float blinkSpeed, float duration)
    {
        StartCoroutine(_blinkCOR(obj, blinkSpeed, duration));
    }
    
    IEnumerator _blinkCOR(GameObject obj, float blinkSpeed, float duration)
    {
        obj.SetActive(true);
        Color defualtColor = obj.GetComponent<MeshRenderer>().material.color;
    
        float counter = 0;
        float innerCounter = 0;
    
        bool visible = false;
    
        while (counter < duration)
        {
            counter += Time.deltaTime;
            innerCounter += Time.deltaTime;
    
            //Toggle and reset if innerCounter > blinkSpeed
            if (innerCounter > blinkSpeed)
            {
                visible = !visible;
                innerCounter = 0f;
            }
    
            if (visible)
            {
                //Show
                show(obj);
            }
            else
            {
                //Hide
                hide(obj);
            }
    
            //Wait for a frame
            yield return null;
        }
    
        //Done Blinking, Restore default color then Disable the GameObject
        obj.GetComponent<MeshRenderer>().material.color = defualtColor;
        obj.SetActive(false);
    }
    
    void show(GameObject obj)
    {
        Color currentColor = obj.GetComponent<MeshRenderer>().material.color;
        currentColor.a = 1;
        obj.GetComponent<MeshRenderer>().material.color = currentColor;
    }
    
    void hide(GameObject obj)
    {
        Color currentColor = obj.GetComponent<MeshRenderer>().material.color;
        currentColor.a = 0;
        obj.GetComponent<MeshRenderer>().material.color = currentColor;
    }
