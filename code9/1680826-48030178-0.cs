        public void CreateEmojiList()
        {
            CreateAllEmojis();
            int btnCount = 0;
            foreach(Emoji emoji in emojiList)
            {
                Button btnEmoji = new Button();
                btnEmoji.Size = new Size(40, 36);
                btnEmoji.FlatStyle = FlatStyle.Flat;
                btnEmoji.FlatAppearance.MouseDownBackColor = Color.Cyan;
                btnEmoji.Cursor = Cursors.Hand;
                btnEmoji.Font = new Font("Bahnschrift", 6.75f);
                btnEmoji.Text = emoji.EmojiText;
                btnEmoji.Top = (panel_main.Controls.OfType<Button>().Count<Button>() / 4) * (1 + btnEmoji.Height) + 6;
                btnEmoji.Left = (btnEmoji.Width + 1) * btnCount + 6;
                panel_main.Controls.Add(btnEmoji);
                var emojiCopy = emoji; //don't close on the loop variable!
                btnEmoji.Click += (sender,args) => OnEmojiClick(emojiCopy);
                btnCount++;
                if (btnCount == 4)
                    btnCount = 0;
            }
        }
        protected virtual void OnEmojiClick(Emoji emoji)
        {
            //do something
        }
