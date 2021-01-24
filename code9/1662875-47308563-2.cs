    pubic static ShowEmphasis(this RichTextBox, string text, FontStyle emphasisStyle)
    {
        const string emphasisOn = "<em>";
        const string emphasisOff = "</em>";
        while(!String.IsNullOrEmpty(text))
        {   // still some text to print
            // get the substring until first emphasisOn
            int indexStartEmphasis = text.Index(emphasisOn);
            if (indexStartEmphasis == -1)
            {   // no emphasisOn anymore: write all in emphasisStyle
                richTextBox.AppendText(text, emphasisStyle);
                text = String.Empty; // no text left
            }
            else
            {   // write until emphasisOn:
                string normalText = text.SubString(0, indexStartEmphasis);
                richTextBox.AppendText(normalText, FontStyle.Normal);
                // remove the normalText + <em> from text:
                text = text.Substring(indexStartEmphasis + emphasisOn.Length);
                // do the same until emphasisOff
                int indexStopEmphasis = text.Index(emphasisOff);
                if (indexStopEmphasis == -1)
                {   // no emphasisOff anymore: write all in emphasisStyle
                    richTextBox.AppendText(text, FontStyle.Normal);
                    text = String.Empty; // no text left
                }
                else
                {   // write until emphasisOff in emphasisStyle:
                    string emphasizedText = text.SubString(0, indexStopEmphasis);
                    richTextBox.AppendText(emphasizedText, emphasisStyle);
                    // remove the emphasizedlText + </em> from text:
                    text = text.Substring(indexStopEmphasis + emphasisOff.Length);
                }
            }
        }
    }
                 
            else
            {   
            }
            string normalText = text.Substring(0, indexStartEmphasis
        }
    }
