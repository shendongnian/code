    public static void Main()
    {
        var dynamicAdd2 = new DynamicMethod("add",
            typeof(string),
            new[] { typeof(Program), typeof(TestType) },
            typeof(Program).Module,
            false);
        var add2Body = typeof(Program).GetMethod("add2").GetMethodBody();
        var add2ILStream = add2Body.GetILAsByteArray();
        var dynamicIlInfo = dynamicAdd2.GetDynamicILInfo();
        var token = dynamicIlInfo.GetTokenFor(typeof(TestType).GetField("Name").FieldHandle);
        var tokenBytes = BitConverter.GetBytes(token);
        //This tries to find index of token used by ldfld by searching for it's opcode (0x7B) in IL stream.
        //Token follows this instructions so I add +1. This works well for this simple method, but
        //will not work in general case, because IL stream could contain 0x7B on other unrelated places.
        var tokenIndex = add2ILStream.ToList().IndexOf(0x7b) + 1;
        Array.Copy(tokenBytes, 0, add2ILStream, tokenIndex, 4);//
        //Copy signature of local variables from original add2 method
        var localSignature = SignatureHelper.GetLocalVarSigHelper();
        var localVarTypes = add2Body.LocalVariables.Select(_ => _.LocalType).ToArray();
        localSignature.AddArguments(localVarTypes, null, null);
        dynamicIlInfo.SetLocalSignature(localSignature.GetSignature());
        dynamicIlInfo.SetCode(add2ILStream, 1);
        var test2 = (Func<TestType, string>)dynamicAdd2.CreateDelegate(typeof(Func<TestType, string>));
        var ret2 = test2(new TestType());
    }
