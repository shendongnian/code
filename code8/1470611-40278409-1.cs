    private async void LoadButton_Click(object sender, EventArgs e)
    {
        for (int index = 0; index < 200; ++index)
        {
            // start getting the thumnail
            // as you don't need it yet, don't await
            var taskGetThumbNail = GetThumbnailForRow(...);
            // since you're not awaiting this statement will be done as soon as
            // the thumbnail task starts awaiting
            // you have something to do, you can continue initializing the data
            var row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell 
            { 
                ValueType = typeof(int), 
                Value = itemId 
            });
            // etc.
            // after a while you need the thumbnail, await for the task
            ImageResult thumbnail = await taskGetThumbNail;
            ProcessThumbNail(thumbNail);
        }
    }
