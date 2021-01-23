    using System;
    using System.Collections.Specialized;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Threading.Tasks;
    
    namespace Dummy
    {
        public class FileDrop
        {
            [ComImport]
            [Guid("3D8B0590-F691-11d2-8EA9-006097DF5BD4")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            public interface IDataObjectAsyncCapability
            {
                void SetAsyncMode([In] Int32 fDoOpAsync);
                void GetAsyncMode([Out] out Int32 pfIsOpAsync);
                void StartOperation([In] IBindCtx pbcReserved);
                void InOperation([Out] out Int32 pfInAsyncOp);
                void EndOperation([In] Int32 hResult, [In] IBindCtx pbcReserved, [In] UInt32 dwEffects);
            }
    
            public static async Task<StringCollection> GetFileDrop(System.Windows.Forms.DataObject dataobject)
            {
                if (dataobject.ContainsFileDropList())
                {
                    var files = dataobject.GetFileDropList();
                    if (files.Count == 0)
                    {
                        // try async version
                        if (await ProcessFileDropAsync(dataobject))
                        {
                            files = dataobject.GetFileDropList();
                        }
                    }
    
                    return files;
                }
                
                // return empty collection    
                return new StringCollection();
            }
    
            private static async Task<bool> ProcessFileDropAsync(System.Windows.Forms.DataObject dataobject)
            {
                // get the internal ole dataobject
                FieldInfo innerDataField = dataobject.GetType().GetField("innerData", BindingFlags.NonPublic | BindingFlags.Instance);
                var oledataobject = (System.Windows.Forms.IDataObject)innerDataField.GetValue(dataobject);
    
                var type = oledataobject.GetType();
                if (type.Name == "OleConverter")
                {
                    // get the COM-object from the OleConverter
                    FieldInfo innerDataField2 = type.GetField("innerData", BindingFlags.NonPublic | BindingFlags.Instance);
                    var item = innerDataField2.GetValue(oledataobject);
    
                    var asyncitem = item as IDataObjectAsyncCapability;
    
                    if (asyncitem != null)
                    {
                        var isasync = 0;
                        asyncitem.GetAsyncMode(out isasync);
                        if (isasync != 0)
                        {
                            var task = Task.Run(() =>
                            {
                                asyncitem.StartOperation(null);
    
                                // calling GetData after StartOperation will trigger the download in Chrome
                                // subsequent calls to GetData return cached data
                                // files are downloaded to something like c:\temp\chrome_drag1234_123456789\yourfilename.here
                                var result = dataobject.GetData("FileDrop"); 
    
                                asyncitem.EndOperation(0, null, 1); // DROPEFFECT_COPY = 1                    
                            });
    
                            await task;
    
                            return true;
                        }                    
                    }
                }
    
                return false;
            }
        }
    }
