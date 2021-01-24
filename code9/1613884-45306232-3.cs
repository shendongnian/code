    private void AddLinkButton(int index)
            {
                LinkButton linkbutton = new LinkButton { ID = string.Concat("txtDomain", index) };
                linkbutton.ClientIDMode = ClientIDMode.Static;
                linkbutton.Text = "Link Button ";
                linkbutton.Click += linkbutton_Click;
                PanelDomain.Controls.Add(linkbutton);
                PanelDomain.Controls.Add(new LiteralControl("<br />"));
            }
