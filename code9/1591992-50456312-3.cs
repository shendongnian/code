    using IDataObject_Com = System.Runtime.InteropServices.ComTypes.IDataObject;
    [StructLayout(LayoutKind.Sequential)]
    public struct Win32Point
    {
        public int x;
        public int y;
    }
    [ComImport]
    [Guid("4657278A-411B-11d2-839A-00C04FD918D0")]
    public class DragDropHelper { }
    [ComVisible(true)]
    [ComImport]
    [Guid("4657278B-411B-11D2-839A-00C04FD918D0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDropTargetHelper
    {
        void DragEnter(
            [In] IntPtr hwndTarget,
            [In, MarshalAs(UnmanagedType.Interface)] IDataObject_Com dataObject,
            [In] ref Win32Point pt,
            [In] int effect);
        void DragLeave();
        void DragOver(
            [In] ref Win32Point pt,
            [In] int effect);
        void Drop(
            [In, MarshalAs(UnmanagedType.Interface)] IDataObject_Com dataObject,
            [In] ref Win32Point pt,
            [In] int effect);
        void Show(
            [In] bool show);
    }
