    // Microsoft.SqlServer.Management.Trace.CTraceObjectsRowsetController
    public unsafe void Initialize(ConnectionInfoBase pConnInfo, string pTemplateFileName)
    {
    	ITraceConnection* ptr = <Module>.CreateOleDbTraceConnection();
    	if (null == ptr)
    	{
    		<Module>.?A0xa0507c21.ProcessError(-2147024882, null);
    	}
    	CTraceControllerBase.ConvertConnectionInfoToITraceConnection(pConnInfo, ptr);
    	ITraceConnection* expr_1D = ptr;
    	int num = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_1D, *(*(int*)expr_1D + 12));
    	if (num < 0)
    	{
    		$ArrayType$$$BY0CAA@G $ArrayType$$$BY0CAA@G = 0;
    		initblk(ref $ArrayType$$$BY0CAA@G + 2, 0, 1022);
    		object arg_50_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt16*), ptr, ref $ArrayType$$$BY0CAA@G, *(*(int*)ptr + 180));
    		<Module>.?A0xa0507c21.ProcessError(num, (ushort*)(&$ArrayType$$$BY0CAA@G));
    	}
    	byte b = 0;
    	byte b2 = 0;
    	int num2 = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte*,System.Byte*,System.UInt16*), ptr, ref b, ref b2, 0, *(*(int*)ptr + 148));
    	if (num2 < 0)
    	{
    		$ArrayType$$$BY0CAA@G $ArrayType$$$BY0CAA@G2 = 0;
    		initblk(ref $ArrayType$$$BY0CAA@G2 + 2, 0, 1022);
    		object arg_9A_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt16*), ptr, ref $ArrayType$$$BY0CAA@G2, *(*(int*)ptr + 180));
    		<Module>.?A0xa0507c21.ProcessError(num2, (ushort*)(&$ArrayType$$$BY0CAA@G2));
    	}
    	if (b < 9)
    	{
    		ITraceConnection* ptr2 = null;
    		int num3 = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,ITraceConnection/eConnectionType,ITraceConnection**), ptr, 0, ref ptr2, *(*(int*)ptr + 28));
    		if (num3 < 0)
    		{
    			$ArrayType$$$BY0CAA@G $ArrayType$$$BY0CAA@G3 = 0;
    			initblk(ref $ArrayType$$$BY0CAA@G3 + 2, 0, 1022);
    			object arg_E6_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt16*), ptr, ref $ArrayType$$$BY0CAA@G3, *(*(int*)ptr + 180));
    			<Module>.?A0xa0507c21.ProcessError(num3, (ushort*)(&$ArrayType$$$BY0CAA@G3));
    		}
    		ITraceConnection* expr_F1 = ptr;
    		object arg_FB_0 = calli(System.UInt32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvStdcall)(System.IntPtr), expr_F1, *(*(int*)expr_F1 + 8));
    		ptr = ptr2;
    		ITraceConnection* expr_101 = ptr2;
    		num2 = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_101, *(*(int*)expr_101 + 12));
    		if (num2 < 0)
    		{
    			$ArrayType$$$BY0CAA@G $ArrayType$$$BY0CAA@G4 = 0;
    			initblk(ref $ArrayType$$$BY0CAA@G4 + 2, 0, 1022);
    			object arg_132_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt16*), ptr, ref $ArrayType$$$BY0CAA@G4, *(*(int*)ptr + 180));
    			<Module>.?A0xa0507c21.ProcessError(num2, (ushort*)(&$ArrayType$$$BY0CAA@G4));
    		}
    	}
    	this.templateFileName = pTemplateFileName;
    	byte* ptr3 = pTemplateFileName;
    	if (ptr3 != null)
    	{
    		ptr3 = RuntimeHelpers.OffsetToStringData + ptr3;
    	}
    	Char modopt(System.Runtime.CompilerServices.IsConst)& char modopt(System.Runtime.CompilerServices.IsConst)& = ptr3;
    	CTraceRowsetCtrl* ptr4 = <Module>.@new(16460u);
    	CTraceRowsetCtrl* ptr5;
    	try
    	{
    		if (ptr4 != null)
    		{
    			ptr5 = <Module>.CTraceRowsetCtrl.{ctor}(ptr4, ptr, char modopt(System.Runtime.CompilerServices.IsConst)&);
    		}
    		else
    		{
    			ptr5 = 0;
    		}
    	}
    	catch
    	{
    		<Module>.delete((void*)ptr4);
    		throw;
    	}
    	this.m_pTraceCtrl = ptr5;
    	if (0 == ptr5)
    	{
    		<Module>.?A0xa0507c21.ProcessError(-2147024882, null);
    	}
    	ITraceConnection* expr_192 = ptr;
    	object arg_19C_0 = calli(System.UInt32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvStdcall)(System.IntPtr), expr_192, *(*(int*)expr_192 + 8));
    }
