    [CommandMethod("GOO")]
        public static void test()
        {
            Database DB = Application.DocumentManager.MdiActiveDocument.Database;
            using (Transaction trans = DB.TransactionManager.StartTransaction())
            {
                LayoutManager LM = LayoutManager.Current;
                string currentLo = LM.CurrentLayout;
                DBDictionary LayoutDict = trans.GetObject(DB.LayoutDictionaryId, OpenMode.ForRead) as DBDictionary;
                Layout CurrentLo = trans.GetObject((ObjectId)LayoutDict[currentLo], OpenMode.ForRead) as Layout;
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
