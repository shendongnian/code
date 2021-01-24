    void My_Filter(object sender, FilterEventArgs e)
    {
        var item = e.Item as yourModelObject;
        if (item == <your test here>)
        {
            e.Accepted = true;
        }
        else
        {
            e.Accepted = false;
        }
    }
