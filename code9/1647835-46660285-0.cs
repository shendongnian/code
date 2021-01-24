    //Get responsive width and height.
    System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
    int height = workingRectangle.Height;
    int width = workingRectangle.Width / 100 * 75;
    //Settings printPreviewControl
    printPreviewControl1.ClientSize = new System.Drawing.Size(width, height);
    printPreviewControl1.Location = new System.Drawing.Point(0, 0);
