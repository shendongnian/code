    [CommandMethod("TEST")]
    public void Test()
    {
        var doc = AcAp.DocumentManager.MdiActiveDocument;
        var db = doc.Database;
        var ed = doc.Editor;
        using (var tr = db.TransactionManager.StartTransaction())
        {
            var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
            // if the bloc table has the block definition
            if (bt.Has("prz_podl"))
            {
                // create a new block reference
                var br = new BlockReference(Point3d.Origin, bt["prz_podl"]);
                // add the block reference to the curentSpace and the transaction
                var curSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                curSpace.AppendEntity(br);
                tr.AddNewlyCreatedDBObject(br, true);
                // set the dynamic property value
                foreach (DynamicBlockReferenceProperty prop in br.DynamicBlockReferencePropertyCollection)
                {
                    if (prop.PropertyName == "par_l")
                    {
                        prop.Value = 500.0;
                    }
                }
            } 
            // save changes
            tr.Commit();
        } // <- end using: disposing the transaction and all objects opened with it (block table) or added to it (block reference)
    }
