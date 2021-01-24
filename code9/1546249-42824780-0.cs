    public function void DrawACell_With_DOUBLELINE_BOTTOM_BORDER(Document doc, PdfWriter writer){
    	PdfPTable pt = new PdfPTable(new float[]{1});	
    	Chunk c = new Chunk("A Cell with doubleline bottom border");
    	int padding = 3;
    	PdfPCell_DoubleLine cell = new PdfPCell_DoubleLine(PdfPTable pt,new Phrase(c), writer, padding);
    	pt.AddCell(cell);
    	doc.Add(pt);
    }
    
    public class PdfPCell_DoubleLine : PdfPCell
    {
    	public PdfPCell_DoubleLine(Phrase phrase, PdfWriter writer, int padding) : base(phrase)
    	{
    		this.HorizontalAlignment = Element.ALIGN_RIGHT;
    		//1. hide existing border
    		this.Border = Rectangle.NO_BORDER;
    		//2. find out the exact position of the cell
    		this.CellEvent = new DLineCell(writer, padding);
    	}
    	public class DLineCell : IPdfPCellEvent
    	{
    		public PdfWriter writer { get; set; }
    		public int padding { get; set; }
    		public DLineCell(PdfWriter writer, int padding)
    		{
    			this.writer = writer;
    			this.padding = padding;
    		}
    
    		public void CellLayout(PdfPCell cell, iTextSharp.text.Rectangle rect, PdfContentByte[] canvases)
    		{
    			//draw line 1
    			PdfContentByte cb = writer.DirectContent;
    			cb.MoveTo(rect.GetLeft(0), rect.GetBottom(0) - padding);
    			cb.LineTo(rect.GetRight(0), rect.GetBottom(0) - padding);
    			//draw line 2
    			cb.MoveTo(rect.GetLeft(0), rect.GetBottom(0) - padding - 2);
    			cb.LineTo(rect.GetRight(0), rect.GetBottom(0) - padding - 2);
    			cb.Stroke();
    		}
    	}
    }
