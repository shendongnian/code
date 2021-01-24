        private void timerViewer(object state)
        {
            irc.sendChatMessage("/mods");
            UpdateStream();
			UpdateChatters();
        } 
		private void UpdateStream()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UpdateStream));
            }
            else
            {
                StreamInformations = TwitchROClient.getStream(TwitchROClient.getIDbyUsername("xzaliax"));
                if (StreamInformations.stream != null)
                {
                    viewers = StreamInformations.stream.Viewers;
                    totalviews = StreamInformations.stream.channel.Views;
                    if (followers == 0)
                    {
                        followers = StreamInformations.stream.channel.Followers;
                    }
                    else
                    {
                        if (followers < StreamInformations.stream.channel.Followers)
                        {
                            newFollower();
                        }
                        followers = StreamInformations.stream.channel.Followers;
                    }
                    InfoStripViewer.Text = "|  " + string.Format(CultureInfo.InvariantCulture, "{0:N0}", viewers).Replace(',', '.') + " :Viewer";
                    InfoStripFollower.Text = "|  " + string.Format(CultureInfo.InvariantCulture, "{0:N0}", followers).Replace(',', '.') + " :Follower ";
                    InfoStripTotalViewer.Text = "|  " + string.Format(CultureInfo.InvariantCulture, "{0:N0}", totalviews).Replace(',', '.') + " :Total Viewers";
                    InfoStripStream.Text = "|  Stream: Online";
                }
                else
                {
                    InfoStripViewer.Text = "|  -- :Viewer";
                    InfoStripFollower.Text = "|  -- :Follower";
                    InfoStripTotalViewer.Text = "|  -- :Total Viewers";
                    InfoStripStream.Text = "|  Stream: Offline";
                }
            }
        }
        private void UpdateChatters()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UpdateChatters));
            }
            else
            {
                ChannenlChatters = TwitchROClient.getChatters(channel);
                lbViewer.Items.Clear();
                if (ChannenlChatters != null)
                {
                    if (ChannenlChatters.AllChatters != null)
                    {
                        tbChat.Text += "Checking the viewer list..." + Environment.NewLine;
                        if (ChannenlChatters.AllChatters.Admins.Count >= 0) lbViewer.Items.Add("_____________Admins_____________");
                        foreach (string admin in ChannenlChatters.AllChatters.Admins)
                        {
                            lbViewer.Items.Add(String.Format("{0,5}", admin));
                        }
                        if (ChannenlChatters.AllChatters.Admins.Count >= 0) lbViewer.Items.Add("");
                        if (ChannenlChatters.AllChatters.Staff.Count >= 0) lbViewer.Items.Add("_____________Stuff______________");
                        foreach (string stuff in ChannenlChatters.AllChatters.Staff)
                        {
                            lbViewer.Items.Add(String.Format("{0,5}", stuff));
                        }
                        if (ChannenlChatters.AllChatters.Staff.Count >= 0) lbViewer.Items.Add("");
                        if (ChannenlChatters.AllChatters.GlobalMods.Count >= 0) lbViewer.Items.Add("___________Global Mods__________");
                        foreach (string globalmods in ChannenlChatters.AllChatters.GlobalMods)
                        {
                            lbViewer.Items.Add(String.Format("{0,5}", globalmods));
                        }
                        if (ChannenlChatters.AllChatters.GlobalMods.Count >= 0) lbViewer.Items.Add("");
                        foreach (string globalMods in ChannenlChatters.AllChatters.GlobalMods)
                        {
                            lbViewer.Items.Add(String.Format("{0,5}", globalMods));
                        }
                        if (ChannenlChatters.AllChatters.Moderators.Count >= 0) lbViewer.Items.Add("___________Moderators___________");
                        foreach (string moderator in ChannenlChatters.AllChatters.Moderators)
                        {
                            lbViewer.Items.Add(String.Format("{0,5}", moderator));
                        }
                        if (ChannenlChatters.AllChatters.Viewers.Count >= 0) lbViewer.Items.Add("____________Viewers_____________");
                        foreach (string viewers in ChannenlChatters.AllChatters.Viewers)
                        {
                            lbViewer.Items.Add(String.Format("{0,5}", viewers));
                        }
                    }
                }
            }
        }
