        public void ListBlocks()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;
            using (var tr = db.TransactionManager.StartOpenCloseTransaction())
            {
                var modelSpace = (BlockTableRecord)tr.GetObject(
                    SymbolUtilityServices.GetBlockModelSpaceId(db), OpenMode.ForRead);
                var brclass = RXObject.GetClass(typeof(BlockReference));
                var blocks = modelSpace
                    .Cast<ObjectId>()
                    .Where(id => id.ObjectClass == brclass)
                    .Select(id => (BlockReference)tr.GetObject(id, OpenMode.ForRead))
                    .GroupBy(br => ((BlockTableRecord)tr.GetObject(
                        br.DynamicBlockTableRecord, OpenMode.ForRead)).Name);
                foreach (var group in blocks)
                {
                    ed.WriteMessage($"\n{group.Key}: {group.Count()}");
                }
                tr.Commit();
            }
        }
