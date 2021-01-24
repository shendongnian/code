    // make sure this all is running in an STA thread (for example, mark Main with the STAThread attribute)
    
    // the file you want to embed
    string embeddedDocumentPath = @"C:\mypath\myfile.txt";
    
    // a temp file that will be created, and embedded in the final .docx    
    string packagePath = @"C:\Temp\test.bin";
    
    // a temp image file that will be created and embedded in the final .docx
    string packageIconPath = @"C:\Temp\test.emf";
    // package embeddedDocumentPath -> create the two OpenXML embeddings
    Packager.PackageFile(packagePath, packageIconPath, embeddedDocumentPath);
    // create the word doc
    using (var doc = WordprocessingDocument.Create(@"C:\mypath\ContainingDocument.docx", WordprocessingDocumentType.Document))
    {
        var main = doc.AddMainDocumentPart();
        // add icon embedding
        var imagePart = main.AddImagePart(ImagePartType.Emf);
        imagePart.FeedData(File.OpenRead(packageIconPath));
        // add package embedding
        var objectPart = main.AddEmbeddedObjectPart("application/vnd.openxmlformats-officedocument.oleObject");
        objectPart.FeedData(File.OpenRead(packagePath));
        // build a sample doc
        main.Document = BuildDocument(main.GetIdOfPart(imagePart), main.GetIdOfPart(objectPart), "Package");
    }
    private static Document BuildDocument(string imagePartId, string objPartId, string progId)
    {
        var shapeId = "R" + Guid.NewGuid().ToString("N");  // come up with a unique name...
        var element =
          new Document(
            new Body(
              new Paragraph(new Run(new Text("This is the containing document."))),
              new Paragraph(new Run(new Text("This is the embedded document: "))),
              new Paragraph(
                new Run(
                  new EmbeddedObject(
                    new v.Shape(
                        new v.ImageData
                        {
                            RelationshipId = imagePartId,   // rel to image part
                            Title = ""                      // this is important!
                        })
                        {
                            Id = shapeId
                        },
                    new ovml.OleObject
                    {
                        Type = ovml.OleValues.Embed,
                        DrawAspect = ovml.OleDrawAspectValues.Icon,
                        ProgId = progId,    // COM progid
                        Id = objPartId,     // rel to embedded part
                        ShapeId = shapeId,  // link to shape
                        ObjectId = "R" + Guid.NewGuid().ToString("N") // come up with a unique name...
                    }
                      )))
              )
          );
        return element;
    }
    
