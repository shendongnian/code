    MethodInfo method = ...
    DynamicMethod dm = new DynamicMethod(
         method.Name,
         method.ReturnType,
         method.GetParameters.Select(pi => pi.ParameterType).ToArray(),
         method.DeclaringType,
         skipVisibility: true\fasle - depends of your need);
    DynamicILInfo ilInfo = dm.GetDynamicILInfo();
    var body = method.GetMethodBody();
    SignatureHelper sig = SignatureHelper.GetLocalVarSigHelper();
    foreach(LocalVariableInfo lvi in body.LocalVariables)
    {
        sig.AddArgument(lvi.LocalType, lvi.IsPinned);
    }
    ilInfo.SetLocalSignature(sig.GetSignature());
    byte[] code = body.GetILAsByteArray();
    ILReader reader = new ILReader(method);
    ILInfoGetTokenVisitor visitor = new ILInfoGetTokenVisitor(ilInfo, code);
    reader.Accept(visitor);
    ilInfo.SetCode(code, body.MaxStackSize);
