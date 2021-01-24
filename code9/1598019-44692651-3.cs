    public void toogleGameObject(GameObject gameobject)
    {
        Debug.Log(gameobject + " " + gameobject.activeSelf);
    
        //In image above this down was under comment, so only Debug.Log was caled with function
        if(gameobject.activeSelf == true)
        {
            gameobject.SetActive(false);
        }
        else
        {
            gameobject.SetActive(true);
        }
    }
