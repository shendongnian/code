    $Source = @"
            using System;
            using iTextSharp.text.pdf;
            using iTextSharp.text.pdf.parser;
    
            public class PdfHelper
            {
                public static void Run(string filePath)
                {
                    PdfReader reader = new PdfReader(filePath);
                    for(var page = 1; page <= reader.NumberOfPages; page++)
                    {
                        PdfTextExtractor.GetTextFromPage(reader, page, new LocationTextExtractionStrategy(new Local()));
                    }
                }
            }
    
            class Local : LocationTextExtractionStrategy.ITextChunkLocationStrategy
            {
                public LocationTextExtractionStrategy.ITextChunkLocation CreateLocation(TextRenderInfo renderInfo, LineSegment baseline)
                {
                    // you need the info per character, so iterate all characters per TextRenderInfo
                    foreach (TextRenderInfo tr in renderInfo.GetCharacterRenderInfos())
                    {
                        LineSegment bl = tr.GetBaseline();
                        // do something with the info
                        Console.WriteLine(tr.GetText() + " @ (" + bl.GetStartPoint()[Vector.I1] + ", " + bl.GetStartPoint()[Vector.I2] + ")");
                    }
                    return new LocationTextExtractionStrategy.TextChunkLocationDefaultImp(baseline.GetStartPoint(), baseline.GetEndPoint(), renderInfo.GetSingleSpaceWidth());
                }
            }
    "@ 
    
    $DLLPath = "$PSScriptRoot\iTextSharp.dll"
    Add-Type -Path $DLLPath
    Add-Type -ReferencedAssemblies $DLLPath -TypeDefinition $Source -Language CSharp 
    
    $Path = "C:\temp\test.pdf"
    [PdfHelper]::Run($Path)
