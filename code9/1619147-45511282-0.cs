    static public void AddDecorations(Annots.Line line, PDFDoc doc)
    {
    ElementReader reader = new ElementReader();
    ElementWriter writer = new ElementWriter();
    ElementBuilder builder = new ElementBuilder();
    
    
    writer.Begin(doc); // start new content stream
    
    
    SDF.Obj old_app_stm = line.GetAppearance();
    reader.Begin(old_app_stm);
    
    
    Element element;
    // isolate PDFNet default appearance in group
    writer.WriteElement(builder.CreateGroupBegin());
    while ((element = reader.Next()) != null)
    {
        writer.WriteElement(element);
    }
    element = builder.CreateGroupEnd();
    writer.WriteElement(element);
    
    
    /////////////////////////////////////////////////////
    // Create matrix to position and rotate new text
    Point start_pt = line.GetStartPoint();
    Point end_pt = line.GetEndPoint();
    double xDiff = end_pt.x - start_pt.x;
    double yDiff = end_pt.y - start_pt.y;
    double angle = Math.Atan2(yDiff, xDiff);
    Matrix2D mtx = Matrix2D.RotationMatrix(-angle);
    mtx.m_h = start_pt.x;
    mtx.m_v = start_pt.y;
    /////////////////////////////////////////////////////
    
    
    element = builder.CreateTextBegin(Font.Create(doc, Font.StandardType1Font.e_helvetica_bold), 8);
    writer.WriteElement(element);
    element = builder.CreateTextRun(String.Format("{0}", line.GetSDFObj().GetObjNum()));
    element.SetTextMatrix(mtx);
    writer.WriteElement(element);
    Rect new_bbox = new Rect();
    element.GetBBox(new_bbox);
    element = builder.CreateTextEnd();
    writer.WriteElement(element);
    
    // update bounding boxes
    Rect old_bbox = new Rect(old_app_stm.FindObj("BBox"));
    old_bbox.Normalize(); // make sure x1,y1 is bottom left
    new_bbox.Normalize();
    new_bbox = new Rect(Math.Min(new_bbox.x1, old_bbox.x1), Math.Min(new_bbox.y1, old_bbox.y1), Math.Max(new_bbox.x2, old_bbox.x2), Math.Max(new_bbox.y2, old_bbox.y2));
    SDF.Obj new_app_stm = writer.End();
    new_app_stm.PutRect("BBox", new_bbox.x1, new_bbox.y1, new_bbox.x2, new_bbox.y2);
    line.SetRect(new_bbox);
    
    line.SetAppearance(new_app_stm);
    }
