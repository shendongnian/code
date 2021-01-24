        public void RenderObject(DocumentRenderer docRenderer, XUnit xPosition, XUnit yPosition, XUnit width, DocumentObject documentObject, XGraphics currentGfx)
        {
            // we risk to cause an exception in order to call the time consuming function PrepareDocument as few times as possible
            try
            {
                docRenderer.RenderObject(currentGfx, xPosition, yPosition, width, documentObject);
            }
            catch
            {
                docRenderer.PrepareDocument();
                docRenderer.RenderObject(currentGfx, xPosition, yPosition, width, documentObject);
            }
        }
