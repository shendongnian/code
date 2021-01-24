    public class Node: DiagramObject
    {
        public Node()
        {
            Size.ValueChanged = RecalculateSnaps;
            Location.ValueChanged = RecalculateSnaps;
        }
