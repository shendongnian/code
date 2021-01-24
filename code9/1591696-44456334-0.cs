    GameObject obj;
    
    void Start()
    {
        obj = GameObject.Find("OBJ");
    }
    IEnumerator BarDeactivate(float sec)
    {
        yield return new WaitForSeconds(sec);
        obj.SetActive(false);
    }
    
    IEnumerator BarReactivate(float sec)
    {
        yield return new WaitForSeconds(sec);
        obj.SetActive(true);
    }
