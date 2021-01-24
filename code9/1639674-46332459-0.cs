    private static void doPrintPreview()
    {
        var pd = new PrintDocument();
        pd.PrintPage += pd_PrintPage;
        var prv = new PrintPreviewDialog();
        prv.Document = pd;
        prv.ShowDialog();
    }
    //Units are in 1/100 of an inch
    private static float leftMargin = 100f;        //Page margins
    private static float rightMargin = 750f;
    private static float topMargin = 100f;
    private static float bottomMargin = 1000f;
    private static int numLabelsToPrint = 200;     //How many we want to print
    private static int numLabelsPrinted = 0;       //How many we have already printed
    private static float labelSizeX = 75;         //Label size
    private static float labelSizeY = 75f;
    private static float labelGutterX = 7.14f;    //Space between labels
    private static float labelGutterY = 7.5f;
    static void pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        e.Graphics.PageUnit = GraphicsUnit.Display;    //Units are 1/100 of an inch
        //start at the left and top margin of the page for a new page
        float xPos = leftMargin;
        float yPos = topMargin;
        using (var p2 = new Pen(Brushes.Red, 3.0f))
        {
            //While there are still labels to print
            while (numLabelsPrinted < numLabelsToPrint)
            {
                //Draw the label  (i just drew a square)
                e.Graphics.DrawRectangle(Pens.Red, xPos, yPos, labelSizeX, labelSizeY);
                numLabelsPrinted++;
                //Set the x position for the next label
                xPos += (labelSizeX + labelGutterX);
                //If the label will be printed beyond the right margin
                if ((xPos + labelSizeX) > rightMargin)
                {
                    //Reset the x position back to the left margin
                    xPos = leftMargin;
                    //Set the y position for the next row of labels
                    yPos += (labelSizeY + labelGutterY);
                    //If the label will be printed beyond the bottom margin
                    if ((yPos + labelSizeY) > bottomMargin)
                    {
                        //Reset the y position back to the top margin
                        yPos = topMargin;
                        //If we still have labels to print
                        if (numLabelsPrinted < numLabelsToPrint)
                        {
                            //Tell the print engine we have more labels and then exit.
                            e.HasMorePages = true;
                            //Notice after setting HasMorePages to true, we need to exit from the method.
                            //The print engine will call the PrintPage method again so we can continue 
                            //printing on the next page.
                            break;   //you could also just use return here
                        }
                    }
                }
            }
        }
    }
