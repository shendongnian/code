    private void toolStripButton81_Click(object sender, EventArgs e)
    {
                        string findterm = string.Empty;
                        findterm = toolStripTextBox2.Text;
                        // the search term - specific word
                        int loopCount = 0;
                        // count the number of instance
                        int findPos = 0;
                        // depending on checkbox settings
                        // whole word search or match case etc
                        
                        try
                        {
                            while (findPos < GetRichTextBox().Text.Length)
                            {
                                if (wholeWordToolStripMenuItem.CheckState == CheckState.Checked & matchCaseToolStripMenuItem.CheckState == CheckState.Checked)
                                {
                                    findPos = GetRichTextBox().Find(findterm, findPos, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
                                }
                                else if (wholeWordToolStripMenuItem.CheckState == CheckState.Checked)
                                {
                                    findPos = GetRichTextBox().Find(findterm, findPos, RichTextBoxFinds.WholeWord);
                                }
                                else if (matchCaseToolStripMenuItem.CheckState == CheckState.Checked)
                                {
                                    findPos = GetRichTextBox().Find(findterm, findPos, RichTextBoxFinds.MatchCase);
                                }
                                else
                                {
                                    findPos = GetRichTextBox().Find(findterm, findPos, RichTextBoxFinds.None);
                                }
                                GetRichTextBox().Select(findPos, toolStripTextBox2.Text.Length);
                                
                                findPos += toolStripTextBox2.Text.Length + 1;
                                loopCount = loopCount + 1;
                                
                            }
                        }
                        catch
                        {
                            findPos = 0;
                            
                        }
                        // at the end bring the cursor at the beginning of the document
                        GetRichTextBox().SelectionStart = 0;
                        GetRichTextBox().SelectionLength = 0;
                        GetRichTextBox().ScrollToCaret();
                        // Show the output in statusbar
                        toolStripStatusLabel2.Text = "Instances: " + loopCount.ToString();               
    }
