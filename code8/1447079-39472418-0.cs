    public interface IField : IComponent
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
