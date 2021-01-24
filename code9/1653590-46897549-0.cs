    public FileContentResult Get()
    {
        byte[] data = new YourPdfService().GeneratePdf();
        return new FileContentResult(data, "application/pdf");
    }
