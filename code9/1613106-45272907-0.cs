        private void btnGetLineVS_Click(object sender, EventArgs e)
        {
            EnvDTE80.DTE2 dte2;
            dte2 = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
            dte2.MainWindow.Activate();
            int line = ((EnvDTE.TextSelection)dte2.ActiveDocument.Selection).ActivePoint.Line;
            
            //Show it to the user the way you like
            StringBuilder builder = new StringBuilder();
            builder.Append(dte2.ActiveDocument.FullName);//The file name
            builder.Append('\t');
            builder.Append(line);//The current line
            if (builder.Length > 0)
            {
                Clipboard.SetText(builder.ToString());
                MessageBox.Show("Copied to clipboard");
            }
            else
                MessageBox.Show("Nothing!");
        }
