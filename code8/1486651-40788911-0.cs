    private void SaveCuratorBtn_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(CuratorIDbox.Text) || string.IsNullOrEmpty(CuratorNamebox.Text))
        {
            MessageBox.Show("please do not leave Boxes empty!");
            return; // If one of the textboxes is empty, we don't continue executing the method
        }
        curator Curator = new curator();
        Curator.ID = CuratorIDbox.Text;
        bool sameid = false;
        for (int i = 0; i < curatorlist.Count; i++)
        {
            if (curatorlist[i].ID == Curator.ID)
            {
                sameid = true;
                break;
            }
        }
        if (sameid)
        {
            MessageBox.Show("ID already exist please try again !");
            return;
        }
        else
        {
            Curator.NAME = CuratorNamebox.Text;
            // I suppose your savefile method can throw exceptions... this has to be in a try-catch block then
            try
            {
                savefile();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
            MessageBox.Show("Curator Saved Thank You");
            CuratorIDbox.Text = "";
            CuratorNamebox.Text = "";
        }
    }
