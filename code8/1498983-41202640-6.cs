    public Script1 script1;
    public Script2 script2;
    public Script3 script3;
    void BlockScripts(bool block)
    {
        //for singleton scripts:
        Script1.Instance.enabled = !block;
        Script2.Instance.enabled = !block;
        Script3.Instance.enabled = !block;
        //for referenced scripts:
        script1.enabled = !block;
        script2.enabled = !block;
        script3.enabled = !block;
        //self
        enabled = !block;
    }
    public void TestClick()
    {
        StartCoroutine(TestMethod);
        ModalMessageBox.setActive(true);
        
        BlockScripts(true);
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
        BlockScripts(false);
    }
    void Update()
    {
    }
