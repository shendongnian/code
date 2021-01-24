    try
            {
                int totalParagraphs = document.Paragraphs.Count;
                string final;
                for (int i = 1; i <= totalParagraphs; i++)
                {
                    string temp = document.Paragraphs[i].Range.Text;
                    float x1 = document.Paragraphs[i].Format.LeftIndent;
                    float x2 = document.Paragraphs[i].Format.RightIndent;
                    float x3 = document.Paragraphs[i].Format.SpaceBefore;
                    float x4 = document.Paragraphs[i].Format.SpaceAfter;
                    if (temp.Length > 1)
                    {
                        Regex regex = new Regex(findText);
                        final = regex.Replace(temp, replaceText);
                        if (final != temp)
                        {
                            document.Paragraphs[i].Range.Text = final;
                            document.Paragraphs[i].Format.LeftIndent = x1;
                            document.Paragraphs[i].Format.RightIndent = x2;
                            document.Paragraphs[i].Format.SpaceBefore = x3;
                            document.Paragraphs[i].Format.SpaceAfter = x4;
                        }
                    }
                }
            } catch (Exception) { }
