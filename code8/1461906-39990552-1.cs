    private IEnumerator CororRoutine(Material cubeMaterial)
    {
        float counter = 0f;
        float changeDuration = 1f;
    
        Color blackColor = Color.black; //OR new Color(0f,0f,1f);
        Color redColor = Color.red; //OR new Color(1f,0f,0f);
    
        //Black To Red
        while (counter < changeDuration)
        {
            counter += Time.deltaTime;
            cubeMaterial.color = Color.Lerp(blackColor, redColor, counter / changeDuration);
            yield return new WaitForEndOfFrame();
        }
    
        counter = 0;
    
        //Red To Black
        while (counter < changeDuration)
        {
            counter += Time.deltaTime;
            cubeMaterial.color = Color.Lerp(redColor, blackColor, counter / changeDuration);
            yield return new WaitForEndOfFrame();
        }
    }
