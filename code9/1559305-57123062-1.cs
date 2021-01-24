static void Main(string[] args) {
    // Create a chart.
    Chart chart1 = new Chart();
    chart1.ChartAreas.Add(new ChartArea());
    Series series1 = new Series();
    series1.Points.Add(new DataPoint(1, 2));
    series1.Points.Add(new DataPoint(2, 4));
    series1.Points.Add(new DataPoint(3, 1));
    chart1.Series.Add(series1);
    // Save the chart to an in-memory (emf) metafile.
    Metafile metafile;
    using (MemoryStream str1 = new MemoryStream()) {
        chart1.SaveImage(str1, ChartImageFormat.Emf);
        byte[] emfBytes = str1.ToArray();
        IntPtr hemf = SetEnhMetaFileBits((uint) emfBytes.Length, emfBytes);
        metafile = new Metafile(hemf, true);
    }
    // Convert the metafile to a WMF and write to a file.
    byte[] wmfBytes = GetWmfByteArray(metafile);
    File.WriteAllBytes(@"c:\temp\test.wmf", wmfBytes);
    // Initialize the document.
    PdfWriter writer = new PdfWriter(@"c:\temp\test.pdf");
    PdfDocument pdf = new PdfDocument(writer);
    Document document = new Document(pdf);
    // Add the image.
    PdfFormXObject xObject1 = new PdfFormXObject(new WmfImageData(@"c:\temp\test.wmf"), pdf);
    Image img1 = new Image(xObject1);
    document.Add(img1);
    document.Close();
}
[DllImport("gdiplus.dll", SetLastError = true)]
static extern int GdipEmfToWmfBits(int hEmf, int uBufferSize, byte[] bBuffer, int iMappingMode, EmfToWmfBitsFlags flags);
[DllImport("gdi32.dll")]
public static extern IntPtr SetEnhMetaFileBits(uint cbBuffer, byte[] lpBuffer);
[Flags]
private enum EmfToWmfBitsFlags
{
    EmfToWmfBitsFlagsDefault = 0x00000000,
    EmfToWmfBitsFlagsEmbedEmf = 0x00000001,
    EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,
    EmfToWmfBitsFlagsNoXORClip = 0x00000004
}
private static byte[] GetWmfByteArray(Metafile mf) {
    const int MM_ANISOTROPIC = 8;
    int handle = mf.GetHenhmetafile().ToInt32();
    int bufferSize = GdipEmfToWmfBits(handle, 0, null, MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsIncludePlaceable);
    byte[] buf = new byte[bufferSize];
    GdipEmfToWmfBits(handle, bufferSize, buf, MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsIncludePlaceable);
    return buf;
}
Note that there is currently no way (that I know of) to place a in-memory WMF in an iText PDF without loading it from a file, because of a bug. I made a [pull request](https://github.com/itext/itext7/pull/41) with a fix, so hopefully they merge it sometime soon.
