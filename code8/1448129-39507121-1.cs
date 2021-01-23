    RichTextBox richTextBox = new RichTextBox ();
    ...
    richTextBox.AllowDrop = true;
    richTextBox.DragEnter += (ss, ee) => { ee.Effect = DragDropEffects.Copy; };
    richTextBox.DragOver += (ss, ee) => { ee.Effect = DragDropEffects.Copy; };
    richTextBox.DragDrop += (ss, ee) 
                           => { splitContainer.Panel_DragDrop(splitContainer.Panel, ee); };
