csharp
 paragraph.Inlines.Clear(); 
Explanation: 
The issue here is that you are clearing all blocks from your FlowDocument, including your single `paragraph` so next time you want to append text in that paragraph it won't work, of course, the text is added to the paragraph referenced by `paragraph` but it is not part of the document any more.
Here are some unit Tests
csharp
 [Apartment(ApartmentState.STA)]
    public class Tests
    {
        public static System.Windows.Media.Brush White = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        protected Paragraph paragraph;
        protected RichTextBox richTextBox1;
        [SetUp]
        public void Setup()
        {
            richTextBox1 = new RichTextBox();
            paragraph = new Paragraph();
            richTextBox1.Document = new FlowDocument(paragraph);
        }
        /// <summary>
        /// This reproduce the issue
        /// </summary>
        [Test]
        public void Adding_Text_After_Blocks_Clear_Should_Not_Work_The_issue()
        {
            paragraph.AddText("Hello, World!");
            string content1 = richTextBox1.GetText();
            Assert.AreEqual("Hello, World!", content1);
            richTextBox1.Document.Blocks.Clear();
            string content2 = richTextBox1.GetText();
            Assert.AreEqual("", content2);
            paragraph.AddText("Howdy!");
            string content3 = richTextBox1.GetText();
            //are not equal
            Assert.AreNotEqual("Howdy!", content3);
        }
        [Test]
        public void Adding_TextAfter_Paragraph_Clear_Should_Work_Solution()
        {
            paragraph.AddText("Hello, World!");
            string content1 = richTextBox1.GetText();
            Assert.AreEqual("Hello, World!", content1);
            paragraph.Inlines.Clear();
            string content2 = richTextBox1.GetText();
            Assert.AreEqual("", content2);
            paragraph.AddText("Howdy!");
            string content3 = richTextBox1.GetText();
            Assert.AreEqual("Howdy!", content3);
        }
        /// <summary>
        /// Keep in mind tha if the  RichTextBox is not readonly, deleting text with CTRL-A + DELETE 
        /// Causes the same issues.
        /// </summary>
        [Test]
        public void Clearing_Blocks_Should_Remove_All_Paragraphs_The_Cause_of_issue()
        {
            paragraph.AddText("Hello, World!");
            string content1 = richTextBox1.GetText();
            Assert.AreEqual("Hello, World!", content1);
            var blocksBefore = richTextBox1.Document.Blocks.ToArray();
            Assert.IsTrue(ReferenceEquals(paragraph, blocksBefore[0]));
            richTextBox1.Document.Blocks.Clear();
            var blocksAfter = richTextBox1.Document.Blocks.ToArray();
            Assert.AreEqual(0, blocksAfter.Length);
        }
        [Test]
        public void Added_New_Text_after_Blocks_Clear_Should_Work()
        {
            paragraph.AddText("Hello, World!");
            string content1 = richTextBox1.GetText();
            Assert.AreEqual("Hello, World!", content1);
            richTextBox1.Document.Blocks.Clear();
            string content2 = richTextBox1.GetText();
            Assert.AreEqual("", content2);
            var p = new Paragraph();
            p.AddText("Howdy!");
            //Add this to the blocks collection!!!!
            richTextBox1.Document.Blocks.Add(p);
            string content3 = richTextBox1.GetText();
            Assert.AreEqual("Howdy!", content3);
        }
    }
    public static class RTBExtentions
    {
        public static string GetText(this RichTextBox rtb)
        {
            return new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text.TrimEnd();
        }
        public static void AddText(this Paragraph paragraph, string textToAdd, Brush foregroundColor = default(Brush))
        {
            paragraph.Inlines.Add(new Run(textToAdd) { Foreground = foregroundColor });
        }
        public static Block[] ToArray(this BlockCollection blocks)
        {
            List<Block> elements = new List<Block>();
            foreach (var item in blocks)  {  elements.Add(item);  }
            return elements.ToArray();
        }
    }
