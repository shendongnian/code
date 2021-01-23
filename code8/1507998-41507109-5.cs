    0:000> !clrstack
    The version of SOS does not match the version of CLR you are debugging.  Please
    load the matching version of SOS for the version of CLR you are debugging.
    CLR Version: 4.0.30319.17929
    SOS Version: 4.6.1590.0
    OS Thread Id: 0x1b50 (0)
            Child SP               IP Call Site
    00000000003edb38 0000000077c7bd7a [HelperMethodFrame: 00000000003edb38] 
    00000000003edc20 000007fedb83f49c System.Linq.Enumerable.SequenceEqual[[System.Byte, mscorlib]](System.Collections.Generic.IEnumerable`1, System.Collections.Generic.IEnumerable`1, System.Collections.Generic.IEqualityComparer`1)
    00000000003edc90 000007fe8d6be73f ILS.MasterController+c__DisplayClass4f.b__4d()
    00000000003edd40 000007fedf9c971c System.Windows.Threading.ExceptionWrapper.InternalRealCall(System.Delegate, System.Object, Int32)
    00000000003edda0 000007fedf9c9587 MS.Internal.Threading.ExceptionFilterHelper.TryCatchWhen(System.Object, System.Delegate, System.Object, Int32, System.Delegate)
    00000000003ede00 000007fedf9aa551 System.Windows.Threading.DispatcherOperation.InvokeImpl()
    00000000003edec0 000007feeadaf8a5 System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
    00000000003ee020 000007feeadaf609 System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
    00000000003ee050 000007feeadaf5c7 System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object)
    00000000003ee0a0 000007fedf9aa181 System.Windows.Threading.DispatcherOperation.Invoke()
    00000000003ee120 000007fedf9c74b1 System.Windows.Threading.Dispatcher.ProcessQueue()
    00000000003ee1e0 000007fedf9c7813 System.Windows.Threading.Dispatcher.WndProcHook(IntPtr, Int32, IntPtr, IntPtr, Boolean ByRef)
    00000000003ee2a0 000007fedf9c994a MS.Win32.HwndWrapper.WndProc(IntPtr, Int32, IntPtr, IntPtr, Boolean ByRef)
    00000000003ee350 000007fedf9c97d0 MS.Win32.HwndSubclass.DispatcherCallbackOperation(System.Object)
    00000000003ee3a0 000007fedf9c95fe System.Windows.Threading.ExceptionWrapper.InternalRealCall(System.Delegate, System.Object, Int32)
    00000000003ee400 000007fedf9c9587 MS.Internal.Threading.ExceptionFilterHelper.TryCatchWhen(System.Object, System.Delegate, System.Object, Int32, System.Delegate)
    00000000003ee460 000007fedf9c692c System.Windows.Threading.Dispatcher.LegacyInvokeImpl(System.Windows.Threading.DispatcherPriority, System.TimeSpan, System.Delegate, System.Object, Int32)
    00000000003ee500 000007fedf9c8e60 MS.Win32.HwndSubclass.SubclassWndProc(IntPtr, Int32, IntPtr, IntPtr)
    00000000003ee600 000007fedfb6e6e7 DomainBoundILStubClass.IL_STUB_ReversePInvoke(Int64, Int32, Int64, Int64)
    00000000003ee898 000007feec01482e [InlinedCallFrame: 00000000003ee898] MS.Win32.UnsafeNativeMethods.DispatchMessage(System.Windows.Interop.MSG ByRef)
    00000000003ee898 000007fedf9d39e0 [InlinedCallFrame: 00000000003ee898] MS.Win32.UnsafeNativeMethods.DispatchMessage(System.Windows.Interop.MSG ByRef)
    00000000003ee870 000007fedf9d39e0 DomainBoundILStubClass.IL_STUB_PInvoke(System.Windows.Interop.MSG ByRef)
    00000000003ee940 000007fedf9c5eb2 System.Windows.Threading.Dispatcher.PushFrameImpl(System.Windows.Threading.DispatcherFrame)
    00000000003ee9e0 000007fedc3172da System.Windows.Application.RunInternal(System.Windows.Window)
    00000000003eea80 000007fedc316bd7 System.Windows.Application.Run()
    00000000003eeac0 000007fe8c8d0107 ILS.App.Main()
    00000000003eedf0 000007feebf6f713 [GCFrame: 00000000003eedf0] 
