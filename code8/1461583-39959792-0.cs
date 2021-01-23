     [DllImport("sibio_multilanguage_c.dll", EntryPoint = "getLabel", CallingConvention = CallingConvention.Cdecl)]
     private static extern UInt32 _getLabel([In] string i_formName, [In] string i_fieldName, 
                                            out IntPtr i_output);
    static public string getLabel(string i_formName, string i_fieldName)
    {
        IntPtr i_result;
        string str = null;
        UInt32 err = _getLabel(i_formName, i_fieldName, out i_result);
        if (0 != err)
        {
            throw  new System.IO.FileNotFoundException();
        }
        str = Marshal.PtrToStringAuto(i_result);
        Marshal.FreeCoTaskMem(i_result);
        return str;
    }
