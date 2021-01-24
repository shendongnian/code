    using System;
    using System.Collections.Generic;
    using System.IO;
    using Apitron.PDF.Kit.FixedLayout;
    using Apitron.PDF.Kit.FixedLayout.Content;
    using Apitron.PDF.Kit.FixedLayout.PageProperties;
    using FixedLayout.Resources;
    using FixedLayout.ContentElements;
    using FlowLayout.Content;
    public void AddParagraph()
        {
            using (Stream stream = new FileStream("file.pdf", FileMode.Open, FileAccess.ReadWrite))
            {
                using (FixedDocument document = new FixedDocument(stream))
                {
                    Page page = document.Pages[0];
                    double minY = page.Boundary.MediaBox.Height;
                    foreach(IContentElement element in page.Elements)
                    {
                        if(element != null)
                        {
                            minY = Math.Min(element.Boundary.Bottom, minY);
                        }
                    }
                    TextBlock textBlock = new TextBlock("I want to show new paragraph here")
                    {
                        Border = new Border(2),
                        BorderColor = RgbColors.Red,
                        Color = RgbColors.Red                
                    };
                    page.Content.SetTranslate(100, minY - 100);
                    page.Content.AppendContentElement(textBlock, 100, 100);
                    // incremental save
                    // document.Save();
                    // or simple save
                    using (Stream outStream = new FileStream("out.pdf", FileMode.Create, FileAccess.ReadWrite))
                    {
                        document.Save(outStream);
                    }
                }
            }
        }
