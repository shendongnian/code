    bool Reqbool = true;
    bool MiniReqbool;
    try
    {
        for (int i = 0; i < ImportList.Count; i++)
        {
            MiniMiniTest mitest = new MiniMiniTest();
            MiniReqbool = mitest.ReqTest(ImportList[i], QValue);
            if(MiniReqbool == false) { throw new Exception(); }
        }
    }
    catch (Exception)
    {
        Reqbool = false;
        MessageBox.Show("Sorry points not found");
    }
