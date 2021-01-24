    public class GridParser : Parser {}
    public class PointParser: Parser {}
    var _dictionary = new Dictionary<int, Type>
    {
        { 1 , typeof(GridParser) },
        { 2 , typeof(PointParser) }
    };
