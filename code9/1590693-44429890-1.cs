    foreach (var oBtn in lClickedButtons)
                {
                    for (var i = 0; i < lColorBrushes.Count; i++)
                    {
                        if (new SoldiColorBrushComparer().Equals(oBtn.Background, lColorBrushes[i]))
                        {
                            //oBtn gets cool stuff
                        }
                    }
                }
