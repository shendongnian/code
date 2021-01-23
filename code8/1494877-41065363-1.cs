        private IEnumerable<ObjectId> GetTextEntitiesOnLayer(Database db, string layerName)
        {
            using (var tr = db.TransactionManager.StartOpenCloseTransaction())
            {
                var blockTable = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                foreach (ObjectId btrId in blockTable)
                {
                    var btr = (BlockTableRecord)tr.GetObject(btrId, OpenMode.ForRead);
                    var textClass = RXObject.GetClass(typeof(DBText));
                    if (btr.IsLayout)
                    {
                        foreach (ObjectId id in btr)
                        {
                            if (id.ObjectClass == textClass)
                            {
                                var text = (DBText)tr.GetObject(id, OpenMode.ForRead);
                                if (text.Layer.Equals(layerName, System.StringComparison.CurrentCultureIgnoreCase))
                                {
                                    yield return id;
                                }
                            }
                        }
                    }
                }
            }
        }
