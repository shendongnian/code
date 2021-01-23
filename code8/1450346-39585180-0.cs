        int i=0;
        call=CreateCall(list[i]);
        while(i<list.count)
    {
        if (!(call.CallState == CallState.Ringing || call.CallState == CallState.Error))
        {
            Thread.Sleep(100);
        }
        else
        { 
            call = CreateCall(list[++i]); 
        }
    }
