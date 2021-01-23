            /// <summary>
        /// Gets a layerName and tries to join all polylines on the given layer        
        /// sends back a little log message to display
        /// </summary>
        /// <param name="layerName"></param>
        /// <returns></returns>
        public static string JoinPolylineOnLayer(Database db, string layerName)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;                        
            TypedValue[] tvs = null;            
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                LayerTable layerTable = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);
                try
                {
                    // get layerid of the selected layer
                    var layerId = layerTable[layerName];
                    // open layer table record with write privileges
                    // if the layer is locked return with an error message that the layer cant be deleted
                    LayerTableRecord layer = (LayerTableRecord)tr.GetObject(layerId, OpenMode.ForWrite);
                    if (layer.IsLocked)
                        return "' cannot be merged(locked).";
                    // create the typevalue (criteria what should be selected)
                    tvs = new TypedValue[] {
                                    new TypedValue(Convert.ToInt32(DxfCode.Operator), "<and"),
                                    new TypedValue(Convert.ToInt32(DxfCode.LayerName), layerName),
                                    new TypedValue(Convert.ToInt32(DxfCode.Operator), "<or"),
                                    new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE"),
                                    new TypedValue(Convert.ToInt32(DxfCode.Start), "LWPOLYLINE"),
                                    new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE2D"),
                                    new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE3D"),
                                    new TypedValue(Convert.ToInt32(DxfCode.Operator), "or>"),
                                    new TypedValue(Convert.ToInt32(DxfCode.Operator), "and>")
                    };
                    // create a list of the entities
                    List<PolylineClass> entities = FillListOfEntities(tvs, tr, ed);
                    
                    for (int i = entities.Count - 1; i >= 0; i--)
                    {                        
                        for (int j = i - 1; j >= 0; j--)
                        {
                            try
                            {
                                // check if start/endpoints are the same
                                // if they are join them and reset the loops and start again
                                if ((entities[i].StartPoint == entities[j].StartPoint) ||
                                    (entities[i].StartPoint == entities[j].EndPoint) ||
                                    (entities[i].EndPoint == entities[j].StartPoint) ||
                                    (entities[i].EndPoint == entities[j].EndPoint))
                                {
                                    Entity srcPLine = entities[i].Ent;
                                    Entity addPLine = entities[j].Ent;
                                    // join both entities
                                    srcPLine.UpgradeOpen();
                                    srcPLine.JoinEntity(addPLine);
                                    
                                    // delete the joined entity
                                    addPLine.UpgradeOpen();
                                    entities.RemoveAt(j);
                                    addPLine.Erase();
                                    // set new start and end point of the joined polyline
                                    entities[i - 1] = new PolylineClass(srcPLine, GetStartPointData(srcPLine), GetEndPointData(srcPLine));
                                    // reset i to the start (as it has changed)
                                    i = entities.Count; 
                                    j = 0;
                                }
                            }
                            catch (System.Exception ex)
                            {
                                ed.WriteMessage("\nError: n{0}", ex.Message);
                            }
                        }
                    }
                    tr.Commit();
                    return "' have been joined";
                }
                //Catch the error and write the errormessage
                catch (System.Exception ex)
                {
                    return Convert.ToString(ex);
                }
            }
        }
        
        /// <summary>
        /// Function to fill the entities list with a give TypedValue
        /// </summary>
        /// <param name="tvs"></param>
        /// <param name="tr"></param>
        /// <param name="ed"></param>
        /// <returns></returns>
        private static List<PolylineClass> FillListOfEntities(TypedValue[] tvs, Transaction tr, Editor ed)
        {
            SelectionFilter oSf = new SelectionFilter(tvs);
            PromptSelectionResult selRes = ed.SelectAll(oSf);
            // if there is a problemw ith the promtselection stop here
            if (selRes.Status != PromptStatus.OK)
            {
                return null;
            }
            // declare a list and fill it with all elements from our selectionfilter
            List<PolylineClass> entities = new List<PolylineClass>();
                        
            foreach (ObjectId obj in selRes.Value.GetObjectIds())
            {
                Entity ent = tr.GetObject(obj, OpenMode.ForRead) as Entity;
                entities.Add(new PolylineClass(ent, GetStartPointData(ent), GetEndPointData(ent)));
            }
            return entities;
        }
        /// <summary>
        /// Function to get the startpoint coordinates of a polyline
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static Point3d GetStartPointData(Entity obj)
        {            
            // If a "lightweight" (or optimized) polyline
            Polyline lwp = obj as Polyline;
            if (lwp != null)
            {
                return new Point3d(lwp.GetPoint2dAt(0).X, lwp.GetPoint2dAt(0).Y, lwp.Elevation);
            }
            else
            {
                // If an old-style, 2D polyline
                Polyline2d p2d = obj as Polyline2d;
                if (p2d != null)
                {
                    return new Point3d (p2d.StartPoint.X, p2d.StartPoint.Y, p2d.Elevation);
                }
                else
                {
                    // If an old-style, 3D polyline
                    Polyline3d p3d = obj as Polyline3d;
                    if (p3d != null)
                    {
                        return p3d.StartPoint;
                    }
                }
            }
            return new Point3d(0, 0, 0);
        }
        /// <summary>
        /// Function to get the endpoint coordinates of a polyline
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static Point3d GetEndPointData(Entity obj)
        {
            // If a "lightweight" (or optimized) polyline
            Polyline lwp = obj as Polyline;
            if (lwp != null)
            {
                return new Point3d(lwp.GetPoint2dAt(lwp.NumberOfVertices - 1).X, lwp.GetPoint2dAt(lwp.NumberOfVertices - 1).Y, lwp.Elevation);
            }
            else
            {
                // If an old-style, 2D polyline
                Polyline2d p2d = obj as Polyline2d;
                if (p2d != null)
                {
                    return new Point3d(p2d.EndPoint.X, p2d.EndPoint.Y, p2d.Elevation);
                }
                else
                {
                    // If an old-style, 3D polyline
                    Polyline3d p3d = obj as Polyline3d;
                    if (p3d != null)
                    {
                       return  p3d.EndPoint;
                    }
                }
            }
            return new Point3d(0, 0, 0);
        }
