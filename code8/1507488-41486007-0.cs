    private void buttonSendDiaeresesToDocx_Click(object sender, EventArgs e)
            {
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filename = @"SpecialCharactersInDocx.docx";
                var filepath = Path.Combine(desktop, filename);
    
                removeExistingFile(filepath);
                createEmptyDocx(filepath);
                rtfEncodedString = new StringBuilder();
                string contentOriginal = "This should be Swedish and Chinese signs -> åäö - 部件名称";
                string rtfStart =
                    "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1031{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}{\\f1\\fmodern\\fprq6\\fcharset134 SimSun;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 ";
                RichTextBox rtfBox = new RichTextBox {Text = contentOriginal};
                string content = rtfBox.Rtf;
                content = content.Replace(rtfStart, "");
                rtfEncodedString.Append(rtfStart);
                rtfEncodedString.Append(content);
                rtfEncodedString.Append(@"\par}");
                addRtfToWordDocument(filepath, rtfEncodedString.ToString());
    
                openDocx(filepath);
            }
