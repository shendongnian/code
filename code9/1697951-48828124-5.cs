            List<string> wordId = _awn.Get_List_Word_Id_From_Value("علامات");
            List<string> synonyms = new List<string>();
            if (wordId != null)
            {
                foreach (string ss in wordId)
                {
                    string temp = _awn.Get_Synset_ID_From_Word_Id(ss);
                    List<string> test = _awn.Get_List_Word_Id_From_Synset_ID(temp);
                    if (test.Count != 0)
                    {
                        foreach (string str in test)
                        {
                            string s = _awn.Get_Word_Value_From_Word_Id(str);
                            if (!synonyms.Contains(s))
                                synonyms.Add(s);
                        }
                    }
                    else
                    {
                        synonyms.Add(textBox1.Text);
                    }
                }
            }
