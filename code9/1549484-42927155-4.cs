    for (int i = 0; i < 256; i++) {
        var check = LDSCheckAsync();
        var idx = Task.WaitAny(Task.Delay(500), check);
        if (idx == 0) {
            throw new TimeoutException("FREEZE DETECTED");
        }
        else if (idx == 1) {
             var result = check.Result;
             // do something with it
        }
    }
