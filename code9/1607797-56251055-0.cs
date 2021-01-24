            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            //Step 2: Draw a rectangle on the page to define the canvas area for the 3D file.
            
            Rectangle rt = new Rectangle(0, 80, 200, 200);
            //Step 3: Initialize a new object of Pdf3DAnnotation, load the.u3d file as 3D annotation.
            
            Pdf3DAnnotation annotation = new Pdf3DAnnotation(rt, "E:\\Testingfolder\\u3dpdf\\BRO_JR_6910K Femur - Bone Model.stl");
            annotation.Activation = new Pdf3DActivation();
            annotation.Activation.ActivationMode = Pdf3DActivationMode.PageOpen;
            //Step 4: Define a 3D view mode.
            Pdf3DView View = new Pdf3DView();
            View.Background = new Pdf3DBackground(new PdfRGBColor());
            View.ViewNodeName = "test";
            View.RenderMode = new Pdf3DRendermode(Pdf3DRenderStyle.Solid);
            View.InternalName = "test";
            View.LightingScheme = new Pdf3DLighting();
            View.LightingScheme.Style = Pdf3DLightingStyle.Day;
            //Step 5: Set the 3D view mode for the annotation.
            annotation.Views.Add(View);
            //Step 6: Add the annotation to PDF.
            page.AnnotationsWidget.Add(annotation);
            //Step 7: Save the file.
            doc.SaveToFile("E:\\Testingfolder\\u3dpdf\\Create3DPdf.pdf", FileFormat.PDF);
