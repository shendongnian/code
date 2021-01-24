        var doc = new Document();
        var shapeCollection = doc.GetChildNodes(Word.NodeType.Shape, true);
                            
                    // getting all images from Word document. 
                    foreach (Shape shape in shapeCollection)
                    {                        
                        if (shape.ShapeType == ShapeType.Image)
                        {
                           //Unloaded image alwasy have 924 imagebytes
                            if (shape.ImageData.ImageBytes.Length == 924)
                            {
                                shape.Width = 72.0;
                                shape.Height = 72.0;                            
                            }
                        }
                     }
 
