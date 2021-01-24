    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;
    using Autodesk.AutoCAD.Runtime;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Autodesk.AutoCAD.EditorInput
    {
        public static class ExtensionMethods
        {
            public static Matrix3d EyeToWorld(this ViewTableRecord view)
            {
                if (view == null)
                    throw new ArgumentNullException("view");
    
                return
                    Matrix3d.Rotation(-view.ViewTwist, view.ViewDirection, view.Target) *
                    Matrix3d.Displacement(view.Target - Point3d.Origin) *
                    Matrix3d.PlaneToWorld(view.ViewDirection);
            }
    
            public static Matrix3d WorldToEye(this ViewTableRecord view)
            {
                return view.EyeToWorld().Inverse();
            }
    
            public static void Zoom(this Editor ed, Extents3d ext)
            {
                if (ed == null)
                    throw new ArgumentNullException("ed");
    
                using (ViewTableRecord view = ed.GetCurrentView())
                {
                    ext.TransformBy(view.WorldToEye());
                    view.Width = ext.MaxPoint.X - ext.MinPoint.X;
                    view.Height = ext.MaxPoint.Y - ext.MinPoint.Y;
                    view.CenterPoint = new Point2d(
                        (ext.MaxPoint.X + ext.MinPoint.X) / 2.0,
                        (ext.MaxPoint.Y + ext.MinPoint.Y) / 2.0);
                    ed.SetCurrentView(view);
                }
            }
    
            public static void ZoomCenter(this Editor ed, Point3d center, double scale = 1.0)
            {
                if (ed == null)
                    throw new ArgumentNullException("ed");
    
                using (ViewTableRecord view = ed.GetCurrentView())
                {
                    center = center.TransformBy(view.WorldToEye());
                    view.Height /= scale;
                    view.Width /= scale;
                    view.CenterPoint = new Point2d(center.X, center.Y);
                    ed.SetCurrentView(view);
                }
            }
    
            public static void ZoomExtents(this Editor ed)
            {
                if (ed == null)
                    throw new ArgumentNullException("ed");
    
                Database db = ed.Document.Database;
                db.UpdateExt(false);
                Extents3d ext = (short)Application.GetSystemVariable("cvport") == 1 ?
                    new Extents3d(db.Pextmin, db.Pextmax) :
                    new Extents3d(db.Extmin, db.Extmax);
                ed.Zoom(ext);
            }
    
            public static void ZoomObjects(this Editor ed, IEnumerable<ObjectId> ids)
            {
                if (ed == null)
                    throw new ArgumentNullException("ed");
    
                using (Transaction tr = ed.Document.TransactionManager.StartTransaction())
                {
                    Extents3d ext = ids
                        .Where(id => id.ObjectClass.IsDerivedFrom(RXObject.GetClass(typeof(Entity))))
                        .Select(id => ((Entity)tr.GetObject(id, OpenMode.ForRead)).GeometricExtents)
                        .Aggregate((e1, e2) => { e1.AddExtents(e2); return e1; });
                    ed.Zoom(ext);
                    tr.Commit();
                }
            }
    
            public static void ZoomScale(this Editor ed, double scale)
            {
                if (ed == null)
                    throw new ArgumentNullException("ed");
    
                using (ViewTableRecord view = ed.GetCurrentView())
                {
                    view.Width /= scale;
                    view.Height /= scale;
                    ed.SetCurrentView(view);
                }
            }
    
            public static void ZoomWindow(this Editor ed, Point3d p1, Point3d p2)
            {
                using (Line line = new Line(p1, p2))
                {
                    ed.Zoom(line.GeometricExtents);
                }
            }
        }
    }
