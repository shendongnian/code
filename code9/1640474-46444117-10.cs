    class OverlappingTextSearchingStrategy : IEventListener
    {
        static List<Vector> UNIT_SQUARE_CORNERS = new List<Vector> { new Vector(0, 0, 1), new Vector(1, 0, 1), new Vector(1, 1, 1), new Vector(0, 1, 1) };
        ICollection<Rectangle> imageRectangles = new HashSet<Rectangle>();
        ICollection<Rectangle> textRectangles = new HashSet<Rectangle>();
        public void EventOccurred(IEventData data, EventType type)
        {
            if (data is ImageRenderInfo) {
                ImageRenderInfo imageData = (ImageRenderInfo)data;
                Matrix ctm = imageData.GetImageCtm();
                List<Rectangle> cornerRectangles = new List<Rectangle>(UNIT_SQUARE_CORNERS.Count);
                foreach (Vector unitCorner in UNIT_SQUARE_CORNERS)
                {
                    Vector corner = unitCorner.Cross(ctm);
                    cornerRectangles.Add(new Rectangle(corner.Get(Vector.I1), corner.Get(Vector.I2), 0, 0));
                }
                Rectangle boundingBox = Rectangle.GetCommonRectangle(cornerRectangles.ToArray());
                Console.WriteLine("Adding image bounding rectangle {0}.", boundingBox);
                imageRectangles.Add(boundingBox);
            } else if (data is TextRenderInfo) {
                TextRenderInfo textData = (TextRenderInfo)data;
                Rectangle ascentRectangle = textData.GetAscentLine().GetBoundingRectangle();
                Rectangle descentRectangle = textData.GetDescentLine().GetBoundingRectangle();
                Rectangle boundingBox = Rectangle.GetCommonRectangle(ascentRectangle, descentRectangle);
                if (boundingBox.GetHeight() == 0 || boundingBox.GetWidth() == 0)
                    Console.WriteLine("Ignoring empty text bounding rectangle {0} for \"{1}\".", boundingBox, textData.GetText());
                else
                {
                    Console.WriteLine("Adding text bounding rectangle {0} for \"{1}\" with 0.5 margins.", boundingBox, textData.GetText());
                    textRectangles.Add(boundingBox.ApplyMargins<Rectangle>(0.5f, 0.5f, 0.5f, 0.5f, false));
                }
            } else if (data is PathRenderInfo) {
                // TODO
            } else if (data != null)
            {
                Console.WriteLine("Ignored {0} event, class {1}.", type, data.GetType().Name);
            }
            else
            {
                Console.WriteLine("Ignored {0} event with null data.", type);
            }
        }
        public ICollection<EventType> GetSupportedEvents()
        {
            // Support all events
            return null;
        }
        public bool foundOverlappingText()
        {
            bool result = false;
            List<Rectangle> textRectangleList = new List<Rectangle>(textRectangles);
            while (textRectangleList.Count > 0)
            {
                Rectangle testRectangle = textRectangleList[textRectangleList.Count - 1];
                textRectangleList.RemoveAt(textRectangleList.Count - 1);
                foreach (Rectangle rectangle in textRectangleList)
                {
                    if (intersect(testRectangle, rectangle))
                    {
                        Console.WriteLine("Found text intersecting text with bounding boxes {0} at {1},{2} and {3} at {4},{5}.",
                                testRectangle, testRectangle.GetX(), testRectangle.GetY(), rectangle, rectangle.GetX(), rectangle.GetY());
                        result = true;// if only the fact counts, do instead: return true
                    }
                }
                foreach (Rectangle rectangle in imageRectangles)
                {
                    if (intersect(testRectangle, rectangle))
                    {
                        Console.WriteLine("Found text intersecting image with bounding boxes {0} at {1},{2} and {3} at {4},{5}.",
                                testRectangle, testRectangle.GetX(), testRectangle.GetY(), rectangle, rectangle.GetX(), rectangle.GetY());
                        result = true;// if only the fact counts, do instead: return true
                    }
                }
            }
            return result;
        }
        bool intersect(Rectangle a, Rectangle b)
        {
            return intersect(a.GetLeft(), a.GetRight(), b.GetLeft(), b.GetRight()) &&
                    intersect(a.GetBottom(), a.GetTop(), b.GetBottom(), b.GetTop());
        }
        bool intersect(float start1, float end1, float start2, float end2)
        {
            if (start1 < start2)
                return start2 <= end1;
            else
                return start1 <= end2;
        }
    }
