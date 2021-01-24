    for (int i = 0; i < ImportList.Count; i++)
    {
        MiniMiniTest mitest = new MiniMiniTest();
        if (!mitest.ReqTest(ImportList[i], QValue))
        {
            Reqbool = false;
            break;
        }
    }
