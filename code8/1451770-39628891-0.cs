        void changeLine(RichTextBox RTB, int line, string text)
        {
            int s1 = RTB.GetFirstCharIndexFromLine(line);
            int s2 = line < RTB.Lines.Count() - 1 ?
                      RTB.GetFirstCharIndexFromLine(line + 1) - 1 :
                      RTB.Text.Length;
            RTB.Select(s1, s2 - s1);
            RTB.SelectedText = text;
        }
        private void trackbarpercent_Click(object sender, EventArgs e)
        {
            changeLine(richTextBox1, 7, "aimbot_aimtime=" + aimtimetrackbar.Value + ".000000");
        }
