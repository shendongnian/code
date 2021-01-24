    using System;
    using System.Collections.Generic;
    using System.IO;
    using Apitron.PDF.Kit.FixedLayout;
    using Apitron.PDF.Kit.FixedLayout.Content;
    using Apitron.PDF.Kit.FixedLayout.PageProperties;
    using FixedLayout.Resources;
    using FixedLayout.ContentElements;
    public bool CheckIfTextIsOverlapped()
        {
            using (Stream stream = new FileStream("file.pdf", FileMode.Open, FileAccess.ReadWrite))
            {
                using (FixedDocument document = new FixedDocument(stream))
                {
                    Page page = document.Pages[0];
                    IList<Boundary> boundaries = new List<Boundary>();
                    foreach(Annotation annotation in page.Annotations)
                    {
                        boundaries.Add(annotation.Boundary);
                    }
                    foreach(IContentElement element in page.Elements.GetByFilter(new ElementsFilter(null, ElementType.Text)))
                    {
                        TextContentElement text = element as TextContentElement;
                        
                        if (text != null)
                        {
                            foreach(TextSegment segment in text.Segments)
                            {
                                Boundary boundary = segment.Boundary;
                                foreach(Boundary loadedBoundary in boundaries)
                                {
                                    if(Boundary.HaveIntersection(loadedBoundary, boundary))
                                    {
                                        return true;
                                    }
                                }
                                boundaries.Add(boundary);
                            }
                        }
                    }                    
                }
            }
            return false;
        }
