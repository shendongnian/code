    public void UserAdded(UserControl1 sender, UserInfoArgs args)
    {
        sender.Hide();
        UserControl2 u2 = new UserControl2();
        this.panelMain.Controls.Add(u2);
        u2.listView1.Items.Add(new ListViewItem(new[]{
                            args.name,
                            args.email,
                            args.phone,
                            args.color}));
    }
