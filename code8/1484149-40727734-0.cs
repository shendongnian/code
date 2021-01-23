    single s7 = Convert.ToSingle(textBox7.Text);
    single s6 = Convert.ToSingle(textBox6.Text);
    for (int i = 0; i < raster_max; i++)
    {
        foreach (var sublist in RasterSet)
        {
            if (RasterSet.IndexOf(sublist) == i)
            {
                foreach (var dataPt in sublist)
                {
                    if (dataPt.Y >= s7 && dataPt.Y <= s6)
                    {
                        test[0][i] = dataPt.A - avgbias[6][i];
                        if (dataPt.A - avgbias[6][i] <= tA)
                        {
                            corrA[i]++;
                        }
                    }
                }
            }
        }
    }
