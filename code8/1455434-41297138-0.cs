    private void button1_Click(object sender, RibbonControlEventArgs e)
    {
            Visio::Application application = Globals.ThisAddIn.Application;
            Visio::Page page = application.ActivePage;
            Visio::Document basicStencil = application.Documents.OpenEx("basic_u.vssx", (short)(Visio.VisOpenSaveArgs.visOpenRO | Visio.VisOpenSaveArgs.visOpenHidden));
            var master = basicStencil.Masters.ItemU["Rectangle"];
            double pinX = 5.5;
            double pinY = 5.5;
            double height = 2.0;
            double width = 2.0;
            Visio::Shape shape = page.Drop(master, pinX, pinY);
            String text = "I am here";
            shape.Text = text;
            Visio.Cell cell = shape.get_CellsU("Height");
            cell.ResultIUForce = height;
            cell = shape.get_CellsU("Width");
            cell.ResultIUForce = width;
            
            
            double Left = 0.0;
            double Right = 0.0;
            double Bottom = 0.0;
            double Top = 0.0;
                  shape.BoundingBox((short)Visio.VisBoundingBoxArgs.visBBoxDrawingCoords, out Left, out Bottom, out Right, out Top);
            Console.WriteLine(Left);     //4.5
            Console.WriteLine(Right);   //6.5
            Console.WriteLine(Bottom); //6.5
            Console.WriteLine(Top);       //4.5
    }
