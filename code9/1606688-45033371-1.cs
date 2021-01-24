        private void WebSocketClientControl1_OnChatNotification(List<SocketUI.SocketUi> sender)
        {
            foreach (SocketUi socketUi in sender)
            {
                switch (socketUi.DSocketType)
                {
                    case SocketEnums.DSocketType.Chat:
                        foreach (SocketUI.tb_Chat chatUi in socketUi.Chats)
                        {
                         
                                    for (int i = 0; i < ASPxPageControl1.TabPages.Count; i++)
                                    {
                                        if (ASPxPageControl1.TabPages[i].Name == "uxTabPage_" + _channels[i].ID.ToString())
                                        {
                                            switch (chatUi.ChatMessegeType)
                                            {
                                                case (int)Enums.ChatMessegeType.Message:
                                                   SetNewMessageOnUi(HelperD.UiChat_To_Tb_Chat(chatUi));
                                                    break;
                                                case (int)Enums.ChatMessegeType.Readed:
                                                    break;
                                                case (int)Enums.ChatMessegeType.OnLinedUser:
                                                    break;
                                                case (int)Enums.ChatMessegeType.OffLinedUser:
                                                    break;
                                                case (int)Enums.ChatMessegeType.JoinChannle:
                                                case (int)Enums.ChatMessegeType.LeftChannle:
                                                    GetUserChannel(chatUi.ChannelID.ID);
                                                    break;
                                                case (int)Enums.ChatMessegeType.TypingUser:
                                                    for (int j = 0; j < ASPxPageControl1.TabPages[i].Controls.Count; j++)
                                                    {
                                                        if (ASPxPageControl1.TabPages[i].Controls[j] is System.Web.UI.WebControls.Label &&
                                                            ASPxPageControl1.TabPages[i].Controls[j].ID ==
                                                            "uxLabel_Status" + ASPxPageControl1.TabPages[i].DataItem.ToString())
                                                        {
                                                    System.Web.UI.WebControls.Label uxLabel_StatusTemp = new System.Web.UI.WebControls.Label();
                                                            uxLabel_StatusTemp = (System.Web.UI.WebControls.Label)ASPxPageControl1.TabPages[i].Controls[j];
                                                            uxLabel_StatusTemp.Text = " درحال تایپ " + socketUi.UserName + "...";
                                                          //  timer1.Start();
                                                        }
                                                    }
                                                    break;
                                    
                                    }//End For
                                     // listBox_Message.Items.Add("Me:=>" + chatUi.Message + "\n\r");
                                }
                            }
                        }//End For
                        break;
                }
            }
        }
        private void SetNewMessageOnUi(UiSideLanguage.Database.Chat.tb_Chat item)
        {
            ASPxTextBox_Message.Text = "";
            for (int i = 0; i < ASPxPageControl1.TabPages.Count; i++)
            {
                for (int j = 0; j < ASPxPageControl1.TabPages[i].Controls.Count; j++)
                {
                    if (ASPxPageControl1.TabPages[i].Controls[j] is System.Web.UI.WebControls.ListBox && ASPxPageControl1.TabPages[i].Controls[j].ID == "uxListView_Chat" + ASPxPageControl1.TabPages[i].DataItem.ToString())
                    {
                        System.Web.UI.WebControls.ListBox userListView = (System.Web.UI.WebControls.ListBox)ASPxPageControl1.TabPages[i].Controls[j];
                        System.Web.UI.WebControls.ListItem listViewItemTemp = new System.Web.UI.WebControls.ListItem();
                        if (item.AddUser.ID == Language.CacheEntity.CurrentUser.ID)
                        {
                            listViewItemTemp.Text = " :من " + item.Message;
                            //   listViewItemTemp.ForeColor = Color.DarkCyan;
                        }
                        else
                        {
                            listViewItemTemp.Text = item.AddUser.UserName + " : " + item.Message;
                            //    listViewItemTemp.ForeColor = Color.DarkRed;
                        }
                        listViewItemTemp.Value = item.MessageFlagID.ToString();
                        System.Web.UI.WebControls.ListItem isHaveChatItem = null;
                        foreach (System.Web.UI.WebControls.ListItem chatitemListView in userListView.Items)
                        {
                            if (Language.HelperD.GetLong(chatitemListView.Value) == item.MessageFlagID)
                            {
                                isHaveChatItem = chatitemListView;
                                break;
                            }
                        }
                        if (isHaveChatItem != null)
                        {
                            if (item.AddUser.ID == Language.CacheEntity.CurrentUser.ID)
                            {
                                isHaveChatItem.Text = " :من " + item.Message;
                                //   isHaveChatItem.ForeColor = Color.DarkCyan;
                            }
                            else
                            {
                                isHaveChatItem.Text = item.ToUser.UserName + " : " + item.Message;
                                // isHaveChatItem.ForeColor = Color.DarkRed;
                            }
                            isHaveChatItem.Value = item.MessageFlagID.ToString();
                        }
                        else
                        {
                            userListView.Items.Add(listViewItemTemp);
                        }
                    }
                }
            }
        }
