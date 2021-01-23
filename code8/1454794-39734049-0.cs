    public IEnumerator LoadMap(){
            Debug.Log("Generating New Map...");
            GenerateMap();            
            while(generated==false){
                 yield return new WaitForSeconds(0.1f);
            }
            Debug.Log("New Map Generated!");
    }
