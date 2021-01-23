    public GameObject ModalMessageBox;//game object of message box with a mask
    public void TestClick()
    {
        StartCoroutine(TestMethod);
        ModalMessageBox.setActive(true);
    }
    IEnumerator TestMethod()
    {
        float time = 0;
        while (time <= 20)
        {
            yield return new WaitForSeconds(.1f);
            time++;
            Debug.Log("Im doing heavy work");
        }
        ModalMessageBox.setActive(false);
    }
    void Update()
    {
        if(ModalMessageBox.activeSelf)
        {
            //handle message box
        }
        else
        {
            //handle normal update stuff
        }
    }
