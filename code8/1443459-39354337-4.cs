    public class NonNull 
    {
        public static void CreateIL(ILGenerator il, FieldBuilder field)
        {
            il.Emit(OpCodes.Ldarg_1); // Push "value" on the stack
            il.Emit(OpCodes.Call, typeof(Utils).GetMethod("checkIfNull"));
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, field);   // Set the field "_Name" to "value"
            il.Emit(OpCodes.Ret);
        }
    }
