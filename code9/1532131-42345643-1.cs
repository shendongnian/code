    > typeof<U>.GetMember("get_U1");;
    val it : System.Reflection.MemberInfo [] =
      [|U get_U1()
          {Attributes = PrivateScope, Public, Static;
           CallingConvention = Standard;
           ContainsGenericParameters = false;
           CustomAttributes = seq [[Microsoft.FSharp.Core.CompilationMappingAttribute((Microsoft.FSharp.Core.SourceConstructFlags)8, (Int32)0)]];
    ...
    > typeof<U>.GetMember("NewU2");;
    val it : System.Reflection.MemberInfo [] =
      [|U NewU2(Int32)
          {Attributes = PrivateScope, Public, Static;
           CallingConvention = Standard;
           ContainsGenericParameters = false;
           CustomAttributes = seq [[Microsoft.FSharp.Core.CompilationMappingAttribute((Microsoft.FSharp.Core.SourceConstructFlags)8, (Int32)1)]];
