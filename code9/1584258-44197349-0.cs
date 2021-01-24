    public static void HtmlFormatting() 
    {
        // Create a blank document object
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);
    
        // Set up and pass the object which implements the handler methods.
        doc.NodeChangingCallback = new HandleNodeChanging_FontChanger();
        // Insert sample HTML content
        builder.InsertHtml("<p>Hello World</p>");
        doc.NodeChangingCallback = null;
    
        builder.InsertHtml("<p>Some Test Text</p>");
    
    
        doc.Save(@"Out.docx");
    }
    
    
    
    public class HandleNodeChanging_FontChanger : INodeChangingCallback
    {
        // Implement the NodeInserted handler to set default font settings for every Run node inserted into the Document
        void INodeChangingCallback.NodeInserted(NodeChangingArgs args)
        {
                
            // Change the font of inserted text contained in the Run nodes.
            if (args.Node.NodeType == NodeType.Run)
            {
                    
                Run run = (Run)args.Node;
                Console.WriteLine(run.Text);
                run.Font.StyleName = "Intense Emphasis";
                // Aspose.Words.Font font = ((Run)args.Node).Font;
                // font.Size = 24;
                // font.Name = "Arial";
            }
        }
    
        void INodeChangingCallback.NodeInserting(NodeChangingArgs args)
        {
            // Do Nothing
        }
    
        void INodeChangingCallback.NodeRemoved(NodeChangingArgs args)
        {
            // Do Nothing
        }
    
        void INodeChangingCallback.NodeRemoving(NodeChangingArgs args)
        {
            // Do Nothing
        }
    }
