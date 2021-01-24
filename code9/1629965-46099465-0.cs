                        RadioButtonList rblEscala = new RadioButtonList();
                        rblEscala.ID = "rblRes";
                        rblEscala.CssClass = "star-cb-group";
                        rblEscala.Style.Add("height", "auto !important;");
                        for (int i = 5; i >= 1; i--)
                        {
                            //rblEscala.Items.Add(new ListItem(i.ToString(), i.ToString()));
                            rblEscala.Items.Add(new ListItem("☆", i.ToString()));
                        }
                        rblEscala.RepeatDirection = RepeatDirection.Horizontal;
                        placeholder.Controls.Add(rblEscala);
