    private static void DetectSpecialCharracterByType(bool isLastIndex, StringBuilder fontText, string tag, bool ifSpecialType, ref bool IfStop, ref bool ifFirstSpecialCharacter, Characters ch)
            {
                if (ifSpecialType)
                {
                    //If it is the first character of the word, put the <b> or <i> at the beginning.
                    if (ifFirstSpecialCharacter)
                    {
                        fontText.Append(tag);
                        ifFirstSpecialCharacter = false;
                        IfStop = false;
                    }
                    //This is a edge case.If the last word of the text is bold or italic, put the </b> or </i>
                    if (isLastIndex)
                    {
                        fontText.Append(ch.Text);
                        fontText.Append(tag.Insert(1, "/"));
                    }
                    else
                        fontText.Append(ch.Text);
                }
                else
                {
                    //If it is the last character of one word, add </b> or </i> at the end.
                    if (!IfStop && tag != "")
                    {
                        fontText.Append(tag.Insert(1, "/"));
                        IfStop = true;
                        ifFirstSpecialCharacter = true;
                    }
                    fontText.Append(ch.Text);
                }
            }
