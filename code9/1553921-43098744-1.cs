    public bool IsCalled(ConstructorInfo derivedConstructor, ConstructorInfo baseConstructor)
    {
        var body = derivedConstructor.GetMethodBody();
        var expectedConstructorToken = baseConstructor.MetadataToken;
        byte[] il = body.GetILAsByteArray();
        var codes = new Dictionary<short, OpCode>();
        var fields = typeof(OpCodes).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        foreach (var field in fields)
        {
            var value = field.GetValue(null);
            if (!(value is OpCode)) { continue; }
            var opCode = (OpCode)value;
            codes.Add(opCode.Value, opCode);
        }
        var operandSizes = new Dictionary<OperandType, int>();
        // https://msdn.microsoft.com/en-us/library/system.reflection.emit.operandtype(v=vs.110).aspx
        operandSizes.Add(OperandType.InlineBrTarget, 4);
        operandSizes.Add(OperandType.InlineField, 4);
        operandSizes.Add(OperandType.InlineI, 4);
        operandSizes.Add(OperandType.InlineI8, 8);
        operandSizes.Add(OperandType.InlineMethod, 4);
        operandSizes.Add(OperandType.InlineNone, 0);
        operandSizes.Add(OperandType.InlineR, 8);
        operandSizes.Add(OperandType.InlineSig, 4);
        operandSizes.Add(OperandType.InlineString, 4);
        operandSizes.Add(OperandType.InlineSwitch, 4);
        operandSizes.Add(OperandType.InlineType, 32);
        operandSizes.Add(OperandType.InlineVar, 2);
        operandSizes.Add(OperandType.ShortInlineBrTarget, 1);
        operandSizes.Add(OperandType.ShortInlineI, 1);
        operandSizes.Add(OperandType.ShortInlineR, 4);
        operandSizes.Add(OperandType.ShortInlineVar, 1);
        var i = 0;
        while(i < il.Length) {
            OpCode operation = OpCodes.Nop;
            if (il[i] == 0xfe)
            {
                operation = codes[BitConverter.ToInt16(il, i)];
            }
            else
            {
                operation = codes[(short)il[i]];
            }
            i += operation.Size;
            if (operation.OperandType == OperandType.InlineMethod)
            {
                var token = BitConverter.ToInt32(il, i);
                if (token == expectedConstructorToken) { return true; }
            }
            i += operandSizes[operation.OperandType];
        }
        return false;
    }
