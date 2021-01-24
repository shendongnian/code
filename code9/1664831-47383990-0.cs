    IEnumerator LightsEffect()
    {
        while(true) {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<Renderer>().material.color = Color.red;
            }
            yield return new WaitForSeconds(.5f);
        
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<Renderer>().material.color = Color.green;
            }
            yield return new WaitForSeconds(.5f); 
        }
    }
