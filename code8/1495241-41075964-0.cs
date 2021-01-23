    //usings:
    using TCD.System.TouchInjection;
    using static TCD.System.TouchInjection.TouchInjector;
    
    // code:
    
    InitializeTouchInjection();
    var pointer = new PointerTouchInfo();
    //We can add different additional touch data
    pointer.TouchMasks = TouchMask.PRESSURE;
    pointer.Pressure = 100;
    //Pointer ID is for gesture tracking
    pointer.PointerInfo.PointerId = 1;
    pointer.PointerInfo.pointerType = PointerInputType.TOUCH;
    pointer.PointerInfo.PtPixelLocation.X = 200;
    pointer.PointerInfo.PtPixelLocation.Y = 200;
    pointer.PointerInfo.PointerFlags = PointerFlags.INRANGE | PointerFlags.INCONTACT | PointerFlags.DOWN;
    InjectTouchInput(1, new[] { pointer });
    //Hold touch for some time
    Thread.Sleep(100);
    pointer.PointerInfo.PointerFlags = PointerFlags.UPDATE;
    InjectTouchInput(1, new []{ pointer });
