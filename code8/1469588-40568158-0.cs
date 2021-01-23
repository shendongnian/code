    printPreviewDialog1.Document = printDocument1;
    ToolStripButton b = new ToolStripButton();
    b.Image = Properties.Resources.PrintIcon;
    b.DisplayStyle = ToolStripItemDisplayStyle.Image;
    b.Click += printPreview_PrintClick;
    ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.RemoveAt(0);
    ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.Insert(0, b);
    printPreviewDialog1.ShowDialog();
