        private IEnumerable<ObjectId> GetEntitiesOnLayer(Database db, string layerName)
        {
            using (var tr = db.TransactionManager.StartOpenCloseTransaction())
            {
                var blockTable = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                foreach (ObjectId btrId in blockTable)
                {
                    var btr = (BlockTableRecord)tr.GetObject(btrId, OpenMode.ForRead);
                    if (btr.IsLayout)
                    {
                        foreach (ObjectId id in btr)
                        {
                            var ent = (Entity)tr.GetObject(id, OpenMode.ForRead);
                            if (ent.Layer.Equals(layerName, System.StringComparison.CurrentCultureIgnoreCase))
                            {
                                yield return id;
                            }
                        }
                    }
                }
            }
        }
