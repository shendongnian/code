    richTextBox1.AllowDrop = true;
    richTextBox1.DragEnter += (ss, ee) => { ee.Effect = DragDropEffects.Copy; };
    richTextBox1.DragOver += (ss, ee) => { ee.Effect = DragDropEffects.Copy; };
    richTextBox1.DragDrop += (ss, ee) 
                           => { splitContainer.Panel_DragDrop(splitContainer.Panel, ee); };
