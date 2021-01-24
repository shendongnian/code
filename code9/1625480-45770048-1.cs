    private void swaptext()
        {
            using (ac.AcadDocumentLock)
            {
                using (var t = ac.StartTransaction)
                {
                    try
                    {
                        MText tx1 = (MText)ids[0].GetObject(OpenMode.ForRead);
                        MText tx2 = (MText)ids[1].GetObject(OpenMode.ForRead);
                        string conts1 = tx1.Contents;
                        string conts2 = tx2.Contents;
                        Extents3d Ex1 = tx1.GeometricExtents;
                        Extents3d Ex2 = tx2.GeometricExtents;
                        Point3d pos1 = Ex1.MaxPoint.RotateBy(-tx1.Rotation, tx1.Normal, tx1.Location);
                        Point3d pos2 = Ex2.MaxPoint.RotateBy(-tx2.Rotation, tx2.Normal, tx2.Location);
                        if ((tx1.Contents.Contains("TWO")) && (pos1.Y > pos2.Y))
                        {
                            tx1.Contents = conts2;
                            tx2.Contents = conts1;
                        }
                        ids.Clear();
                    }
                    catch (System.Exception ex)
                    {
                        ac.AcadDocument.Editor.WriteMessage("Error: ==>\n{0}\nTrace: ==>\n{1}", ex.Message, ex.StackTrace);
                    }
                    t.Commit();
                }
            }
        }
