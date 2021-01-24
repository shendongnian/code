             if (picBoxes != null)
                {
                    for (int i = 0; i < picBoxes.Length; i++)
                    {
                        if (picBoxes[i].Image != null)
                        {
                            picBoxes[i].Image = null;
                        }
    
                        picBoxes[i].Index = 0;
                        picBoxes[i].ImageIndex = 0;
                        picBoxes[i].Width = 0;
                        picBoxes[i].Height = 0;
                        picBoxes[i] = null;
                    }
    
                    images = null;
                }
