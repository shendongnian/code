            string result;
            //combobox : lg,Sex,stat
            //textbox : name,show
            //button : button1
            switch (lg.SelectedIndex)
            {
                case 0:
                    if (Sex.SelectedIndex == 0)
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Bapak" + name;
                        }
                        else
                        {
                            result = "Mas" + name;
                        }
                    }
                    else
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Ibu" + name;
                        }
                        else
                        {
                            result = "Mbak" + name;
                        }
                    }
                    show.Text = result;
                    break;
                case 1:
                    if (Sex.SelectedIndex == 0)
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Xiansheng" + name;
                        }
                        else
                        {
                            result = "Xiansheng" + name;
                        }
                    }
                    else
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Taitai" + name;
                        }
                        else
                        {
                            result = "Xiaojie" + name;
                        }
                    }
                    show.Text = result;
                    break;
                case 2:
                    if (Sex.SelectedIndex == 0)
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Mr" + name;
                        }
                        else
                        {
                            result = "Mr" + name;
                        }
                    }
                    else
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Mrs" + name;
                        }
                        else
                        {
                            result = "Ms" + name;
                        }
                    }
                    show.Text = result;
                    break;
                case 3:
                    if (Sex.SelectedIndex == 0)
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "San" + name;
                        }
                        else
                        {
                            result = "Kun" + name;
                        }
                    }
                    else
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "San" + name;
                        }
                        else
                        {
                            result = "Chan" + name;
                        }
                    }
                    show.Text = result;
                    break;
                case 4:
                    if (Sex.SelectedIndex == 0)
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Ssi" + name;
                        }
                        else
                        {
                            result = "Hyung" + name;
                        }
                    }
                    else
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Ssi" + name;
                        }
                        else
                        {
                            result = "Noona" + name;
                        }
                    }
                    show.Text = result;
                    break;
                case 5:
                    if (Sex.SelectedIndex == 0)
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Monsieur" + name;
                        }
                        else
                        {
                            result = "Monsieur" + name;
                        }
                    }
                    else
                    {
                        if (stat.SelectedIndex == 0)
                        {
                            result = "Madame" + name;
                        }
                        else
                        {
                            result = "Mademoiselle" + name;
                        }
                    }
                    show.Text = result;
                    break;
            }
