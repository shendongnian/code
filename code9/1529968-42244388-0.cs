    _Mocklogger.Verify(x =>x.LogMessage(LogSeverity.Error, 
                                        expectedException,
      It.Is<System.Reflection.TargetParameterCountException>(CheckException)),
                                        Times.Once);
    private static bool CheckException(System.Reflection.TargetParameterCountException ex){
        //...
    }
