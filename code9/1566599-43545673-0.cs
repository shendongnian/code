    public class ILInstruction
    {
        public ILInstruction(int offset, OpCode code, object operand)
        {
            this.Offset = offset;
            this.Code = code;
            this.Operand = operand;
        }
        // Fields
        public int Offset { get; private set; }
        public OpCode Code { get; private set; }
        public object Operand { get; private set; }
    }
    internal class Decompiler
    {
        private Decompiler() { }
        static Decompiler()
        {
            InitDecompiler();
        }
        private static OpCode[] singleByteOpcodes;
        private static OpCode[] multiByteOpcodes;
        private static void InitDecompiler()
        {
            singleByteOpcodes = new OpCode[0x100];
            multiByteOpcodes = new OpCode[0x100];
            FieldInfo[] infoArray1 = typeof(OpCodes).GetFields();
            for (int num1 = 0; num1 < infoArray1.Length; num1++)
            {
                FieldInfo info1 = infoArray1[num1];
                if (info1.FieldType == typeof(OpCode))
                {
                    OpCode code1 = (OpCode)info1.GetValue(null);
                    ushort num2 = (ushort)code1.Value;
                    if (num2 < 0x100)
                    {
                        singleByteOpcodes[(int)num2] = code1;
                    }
                    else
                    {
                        if ((num2 & 0xff00) != 0xfe00)
                        {
                            throw new Exception("Invalid opcode: " + num2.ToString());
                        }
                        multiByteOpcodes[num2 & 0xff] = code1;
                    }
                }
            }
        }
        public static IEnumerable<ILInstruction> Decompile(MethodBase mi, byte[] ildata)
        {
            Module module = mi.Module;
            ByteReader reader = new ByteReader(ildata);
            while (!reader.Eof)
            {
                OpCode code = OpCodes.Nop;
                int offset = reader.Position;
                ushort b = reader.ReadByte();
                if (b != 0xfe)
                {
                    code = singleByteOpcodes[b];
                }
                else
                {
                    b = reader.ReadByte();
                    code = multiByteOpcodes[b];
                    b |= (ushort)(0xfe00);
                }
                object operand = null;
                switch (code.OperandType)
                {
                    case OperandType.InlineBrTarget:
                        operand = reader.ReadInt32() + reader.Position;
                        break;
                    case OperandType.InlineField:
                        if (mi is ConstructorInfo)
                        {
                            operand = module.ResolveField(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), Type.EmptyTypes);
                        }
                        else
                        {
                            operand = module.ResolveField(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), mi.GetGenericArguments());
                        }
                        break;
                    case OperandType.InlineI:
                        operand = reader.ReadInt32();
                        break;
                    case OperandType.InlineI8:
                        operand = reader.ReadInt64();
                        break;
                    case OperandType.InlineMethod:
                        try
                        {
                            if (mi is ConstructorInfo)
                            {
                                operand = module.ResolveMember(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), Type.EmptyTypes);
                            }
                            else
                            {
                                operand = module.ResolveMember(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), mi.GetGenericArguments());
                            }
                        }
                        catch
                        {
                            operand = null;
                        }
                        break;
                    case OperandType.InlineNone:
                        break;
                    case OperandType.InlineR:
                        operand = reader.ReadDouble();
                        break;
                    case OperandType.InlineSig:
                        operand = module.ResolveSignature(reader.ReadInt32());
                        break;
                    case OperandType.InlineString:
                        operand = module.ResolveString(reader.ReadInt32());
                        break;
                    case OperandType.InlineSwitch:
                        int count = reader.ReadInt32();
                        int[] targetOffsets = new int[count];
                        for (int i = 0; i < count; ++i)
                        {
                            targetOffsets[i] = reader.ReadInt32();
                        }
                        int pos = reader.Position;
                        for (int i = 0; i < count; ++i)
                        {
                            targetOffsets[i] += pos;
                        }
                        operand = targetOffsets;
                        break;
                    case OperandType.InlineTok:
                    case OperandType.InlineType:
                        try
                        {
                            if (mi is ConstructorInfo)
                            {
                                operand = module.ResolveMember(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), Type.EmptyTypes);
                            }
                            else
                            {
                                operand = module.ResolveMember(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), mi.GetGenericArguments());
                            }
                        }
                        catch
                        {
                            operand = null;
                        }
                        break;
                    case OperandType.InlineVar:
                        operand = reader.ReadUInt16();
                        break;
                    case OperandType.ShortInlineBrTarget:
                        operand = reader.ReadSByte() + reader.Position;
                        break;
                    case OperandType.ShortInlineI:
                        operand = reader.ReadSByte();
                        break;
                    case OperandType.ShortInlineR:
                        operand = reader.ReadSingle();
                        break;
                    case OperandType.ShortInlineVar:
                        operand = reader.ReadByte();
                        break;
                    default:
                        throw new Exception("Unknown instruction operand; cannot continue. Operand type: " + code.OperandType);
                }
                yield return new ILInstruction(offset, code, operand);
            }
        }
    }
