    using System;
    using System.Collections.Generic;
    using System.IO;
    using Apitron.PDF.Kit.FixedLayout;
    using Apitron.PDF.Kit.FixedLayout.Content;
    public void CombinePDFDocuments()
        {
            using (Stream stream1 = new FileStream("input1.pdf", FileMode.Open, FileAccess.Read))
            using (Stream stream2 = new FileStream("input2.pdf", FileMode.Open, FileAccess.Read))
            using (Stream stream3 = new FileStream("input3.pdf", FileMode.Open, FileAccess.Read))
            using (Stream stream4 = new FileStream("input4.pdf", FileMode.Open, FileAccess.Read))
            {
                using (FixedDocument doc1 = new FixedDocument(stream1))
                using (FixedDocument doc2 = new FixedDocument(stream2))
                using (FixedDocument doc3 = new FixedDocument(stream3))
                using (FixedDocument doc4 = new FixedDocument(stream4))
                {
                    using (FixedDocument result = new FixedDocument())
                    {
                        Page page = new Page(Boundaries.A4);
                        result.Pages.Add(page);
                        // Left bottom
                        page.Content.AppendContent(doc1.Pages[0].Content);
                        // Left Top
                        page.Content.SetTranslate(0, Boundaries.A7.Height);
                        page.Content.AppendContent(doc2.Pages[0].Content);
                        // Right Top
                        page.Content.SetTranslate(Boundaries.A7.Width, 0);
                        page.Content.AppendContent(doc3.Pages[0].Content);
                        // Right Bottom
                        page.Content.SetTranslate(0, -Boundaries.A7.Height);
                        page.Content.AppendContent(doc4.Pages[0].Content);
                        using (Stream outStream = new FileStream("out.pdf", FileMode.Create, FileAccess.ReadWrite))
                        {
                            result.Save(outStream);
                        }                        
                    }
                }
            }
        }
