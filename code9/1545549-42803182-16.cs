        /// <summary>
        /// 
        /// </summary>
        /// <param name="entries">You will get them from loading your previously saved file</param>
        public void CreateUI(List<ListEntry> entries)
        {
            foreach (ListEntry entry in entries)
            {
                //Create new instance of your UserControl
                TaskView view = new TaskView();
                view.SetFinished(entry.IsFinished);
                view.SetText(entry.Text);
                //Add that to your UI:
                this.flowLayoutPanel1.Controls.Add(view);
            }
        }
