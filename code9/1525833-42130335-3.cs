    using AcAp = Autodesk.AutoCAD.ApplicationServices.Application;
    
    namespace AttributeSyncExternal.AttributeSync
    {
        public class DumpAttributes
        {
            [CommandMethod("LISTATT")]
            public void ListAttributes()
            {
                using (var dlg = new AttributeSyncForm())
                {
                    dlg.BlockName = "Old";
                    if (AcAp.ShowModalDialog(dlg) == DialogResult.OK)
                    {
                        AcAp.ShowAlertDialog(dlg.BlockName);
                    }
                }
            }
        }
    }
