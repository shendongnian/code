    byte[] code = body.GetILAsByteArray();
    ILReader reader = new ILReader(method);
    ILInfoGetTokenVisitor visitor = new ILInfoGetTokenVisitor(ilInfo, code);
    reader.Accept(visitor);
    ilInfo.SetCode(code, body.MaxStackSize);
