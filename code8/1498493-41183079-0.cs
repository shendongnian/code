    public class Shape : ShapeBase,    
    {
     private Shape() {
       //here some inits
     }
     public Shape(DocumentBase doc, ShapeType shapeType);    
     public Chart Chart { get; }
     public bool ExtrusionEnabled { get; }
     public Fill Fill { get; }
     public Color FillColor { get; set; }
     public bool Filled { get; set; }
     public Paragraph FirstParagraph { get; }
     public bool HasChart { get; }
     public bool HasImage { get; }
     public ImageData ImageData { get; }
     public Paragraph LastParagraph { get; }
     public override NodeType NodeType { get; }
     public OleFormat OleFormat { get; }
     public bool ShadowEnabled { get; }
     public SignatureLine SignatureLine { get; }
     public StoryType StoryType { get; }
     public Stroke Stroke { get; }
     public Color StrokeColor { get; set; }
     public bool Stroked { get; set; }
     public double StrokeWeight { get; set; }
     public TextBox TextBox { get; }
     public TextPath TextPath { get; }
     public override bool Accept(DocumentVisitor visitor);
    
    }
