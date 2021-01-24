    bool Reqbool = true;
    bool MiniReqbool = true;
    for (int i = 0; i < ImportList.Count; i++)
    {
        MiniMiniTest mitest = new MiniMiniTest();
        if(!mitest.ReqTest(ImportList[i], QValue)) { MiniReqbool = false; }
    }
    if (MiniReqbool == false)
    {
        Reqbool = false;
        MessageBox.Show("Sorry points not found");
    }
