    public class PdfWriter : DocWriter, 
        IPdfViewerPreferences,
        IPdfEncryptionSettings,
        IPdfVersion,
        IPdfDocumentActions,
        IPdfPageActions,
        IPdfIsoConformance,
        IPdfRunDirection,
        IPdfAnnotations
    {
        // ...
        protected PdfWriter(PdfDocument document, Stream os) : base(document, os) {
            // ...
        }
        // ...
    }
