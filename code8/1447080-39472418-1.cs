    public interface IStyle
    {
        /* Style properties */
    }
    public class Style : IStyle
    {
        /* Style implementations */
    }
    public interface IField : IStyle
    {
        int Xpos { get; set; }
        int Ypos { get; set; }
        int Zindex { get; set; }
    }
    public class Field : Style, IField
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int Zindex { get; set; }
    }
