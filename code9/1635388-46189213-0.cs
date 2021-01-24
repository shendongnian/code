    public static void DelVP(Layout CurrentLo)
        {
            Database DB = Application.DocumentManager.MdiActiveDocument.Database;
            using (Transaction trans = DB.TransactionManager.StartTransaction())
            {
                BlockTableRecord BlkTblRec = trans.GetObject(CurrentLo.BlockTableRecordId, OpenMode.ForRead) as BlockTableRecord;
                foreach (ObjectId ID in BlkTblRec)
                {
                    Viewport VP = trans.GetObject(ID, OpenMode.ForRead) as Viewport;
                    if (VP != null)
                    {
                        VP.UpgradeOpen();
                        VP.Erase();
                    }
                }
                trans.Commit();
            }
        }
