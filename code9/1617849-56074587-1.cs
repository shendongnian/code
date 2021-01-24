    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    namespace VaTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                MarshalVaArgs(vaList => vprintf("%c%d%s", vaList), false, 'a', 123, "bc");
            }
            [DllImport("msvcrt")]  //windows
          //[DllImport("c")]       //linux
            private static extern int vprintf(string format, IntPtr vaList);
            private static int IntSizeOf(Type t)
            {
                return (Marshal.SizeOf(t) + IntPtr.Size - 1) & ~(IntPtr.Size - 1);
            }
            public static void MarshalVaArgs(Action<IntPtr> action, bool? isUnicode, params object[] args)
            {
                var sizes = new int[args.Length];
                for (var i = 0; i < args.Length; i++)
                {
                    sizes[i] = args[i] is string ? IntPtr.Size : IntSizeOf(args[i].GetType());
                }
                var allocs = new List<IntPtr>();
                var offset = 0;
                var result = Marshal.AllocHGlobal(sizes.Sum());
                allocs.Add(result);
                for (var i = 0; i < args.Length; i++)
                {
                    if (args[i] is string)
                    {
                        var s = (string)args[i];
                        var data = default(IntPtr);
                        if (isUnicode.HasValue)
                        {
                            if (isUnicode.Value)
                            {
                                data = Marshal.StringToHGlobalUni(s);
                            }
                            else
                            {
                                data = Marshal.StringToHGlobalAnsi(s);
                            }
                        }
                        else
                        {
                            data = Marshal.StringToHGlobalAuto(s);
                        }
                        allocs.Add(data);
                        Marshal.WriteIntPtr(result, offset, data);
                        offset += sizes[i];
                    }
                    else
                    {
                        Marshal.StructureToPtr(args[i], result + offset, false);
                        offset += sizes[i];
                    }
                }
                action(result);
                foreach (var ptr in allocs)
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }
        }
    }
