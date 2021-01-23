        private void Foo()
        {
            foreach (var Item in query.OrderBy(x=> x.menu_sort))
            {
                var btn = new Button
                {
                    Name = Item.menu_name,
                    Text = Item.menu_description,
                    Tag = Item.menu_name,
                    Size = new Size(107, 50),
                    Font = new Font("B Nazanin",10)
                };
                btn.Click += Btn_Click;
                MainPanel.Controls.Add(btn);
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // now do something with "btn", maybe based on btn.Tag?
        }
