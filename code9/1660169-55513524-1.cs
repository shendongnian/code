    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApp1
    {
        class Program
        {
    
            [ComImport, Guid("D5120AA3-46BA-44C5-822D-CA8092C1FC72")]
            public class FrameworkInputPane
            {
            }
    
            [ComImport, System.Security.SuppressUnmanagedCodeSecurity,
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
            Guid("5752238B-24F0-495A-82F1-2FD593056796")]
            public interface IFrameworkInputPane
            {
                [PreserveSig]
                int Advise(
                    [MarshalAs(UnmanagedType.IUnknown)] object pWindow,
                    [MarshalAs(UnmanagedType.IUnknown)] object pHandler,
                    out int pdwCookie
                    );
    
                [PreserveSig]
                int AdviseWithHWND(
                    IntPtr hwnd,
                    [MarshalAs(UnmanagedType.IUnknown)] object pHandler,
                    out int pdwCookie
                    );
    
                [PreserveSig]
                int Unadvise(
                    int pdwCookie
                    );
    
                [PreserveSig]
                int Location(
                    out Rectangle prcInputPaneScreenLocation
                    );
            }
    
    
            static void Main(string[] args)
            {
                var inputPane = (IFrameworkInputPane)new FrameworkInputPane();
                inputPane.Location(out var rect);
                Console.WriteLine((rect.Width == 0 && rect.Height == 0) ? "Keyboard not visible" : "Keyboard visible");
            }
        }
    }
