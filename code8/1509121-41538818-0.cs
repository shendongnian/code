        private void btnGo_Click(object sender, EventArgs e)
        {
            // start with the base font, then add in each selected style
            Font fnt = new Font(lblFontSample.Font.FontFamily, lblFontSample.Font.Size, FontStyle.Regular);
            if (cbBold.Checked)
            {
                fnt = new Font(lblFontSample.Font, fnt.Style | FontStyle.Bold);
            }
            if (cbItalic.Checked)
            {
                fnt = new Font(lblFontSample.Font, fnt.Style | FontStyle.Italic);
            }
            if (cbUnderline.Checked)
            {
                fnt = new Font(lblFontSample.Font, fnt.Style | FontStyle.Underline);
            }
            lblFontSample.Font = fnt;
        }
