    using System;
    using System.Collections.Generic;
    using System.IO;
    using Apitron.PDF.Kit.FixedLayout;
    using Apitron.PDF.Kit.FixedLayout.Content;
    using Apitron.PDF.Kit.FixedLayout.PageProperties;
    using FixedLayout.Resources;
    using FixedLayout.ContentElements;
            /// <summary>
        /// Gets all text boundaries.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <param name="boundaries">The boundaries.</param>
        public void GetAllTextBoundaries(IContentElementsEnumerator elements, IList<Boundary> boundaries, Boundary offset)
        {
            // We dont count drawings and images here - only text;
            if(elements == null)
            {
                return;
            }
            foreach (IContentElement element in elements)
            {
                TextContentElement text = element as TextContentElement;
                if (text != null)
                {
                    foreach (TextSegment segment in text.Segments)
                    {
                        Boundary currentBoundary = segment.Boundary;
                        if (offset != null)
                        {
                            currentBoundary = new Boundary(currentBoundary.Left + offset.Left, currentBoundary.Bottom + offset.Bottom, currentBoundary.Right + offset.Left, currentBoundary.Top + offset.Bottom);
                        }
                        boundaries.Add(currentBoundary);
                    }
                }
                else if (element is FormContentElement)
                {                    
                    Boundary currentBoundary = (element as FormContentElement).Boundary;
                    if (offset != null)
                    {
                        currentBoundary = new Boundary(currentBoundary.Left + offset.Left, currentBoundary.Bottom + offset.Bottom, currentBoundary.Right + offset.Left, currentBoundary.Top + offset.Bottom);
                    }
                    this.GetAllTextBoundaries((element as FormContentElement).FormXObject.Elements, boundaries, currentBoundary);
                }
            }
        }
        /// <summary>
        /// Checks if text is overlapped.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfTextIsOverlapped(string fileName)
        {
            const double overlapMax = 5;
            using (System.IO.Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                using (FixedDocument document = new FixedDocument(stream))
                {
                    foreach (Page page in document.Pages)
                    {
                        IList<Boundary> boundaries = new List<Boundary>();
                        foreach (Annotation annotation in page.Annotations)
                        {
                            // Actually we need only Normal state, but will check all - to be sure.
                            if(annotation.Appearance.Normal != null)
                            {
                                this.GetAllTextBoundaries(annotation.Appearance.Normal.Elements, boundaries, annotation.Boundary);
                            }
                        }
                        IContentElementsEnumerator elements = page.Elements;
                        this.GetAllTextBoundaries(elements, boundaries, null);
                        for (int i = 0; i < boundaries.Count; i++)
                        {
                            for (int j = i + 1; j < boundaries.Count; j++)
                            {
                                Boundary b1 = boundaries[i];
                                Boundary b2 = boundaries[j];
                                double x1 = Math.Max(b1.Left, b2.Left);
                                double y1 = Math.Max(b1.Bottom, b2.Bottom);
                                double x2 = Math.Min(b1.Right, b2.Right);
                                double y2 = Math.Min(b1.Top, b2.Top);
                                // So we have intersection
                                if (x1 < x2 && y1 < y2)
                                {
                                    if (x1 - x2 >= overlapMax || y1 - y2 >= overlapMax)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    
