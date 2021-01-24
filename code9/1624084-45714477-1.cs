    public class PointElementDataService : ElementDataService<Element>
            {
                public override void InsertElement(Element point) { }
                public override void UpdateElement(ElementKey key, Element point) { }
                public override void DeleteElement(ElementKey key) { }
    
                public static ElementDataService<Element> CreatePointElementDataService()
                {
                    return new PointElementDataService();
                }
            }
