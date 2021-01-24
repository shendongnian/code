        private Dictionary<Point, CheckBox> checkBoxes;
        private Dictionary<Point,CheckBox> GenerateCheckBoxes(Form form, int width, int height, int padding) {
            Dictionary<Point, CheckBox> checkboxes = new Dictionary<Point, CheckBox>();
            for(int x = 0; x < width; x++) {
                for(int y = 0; y < height; y++) {
                    CheckBox checkBox = new CheckBox();
                    Point location = new Point(x*(15+padding), y*(15+padding));
                    //Formatting
                    checkBox.Location = location;
                    checkBox.Text = string.Empty;
                    checkBox.Size = new Size(15,15);
                    //Custom behaviour
                    checkBox.Click += CheckBox_Click;
                    form.Controls.Add(checkBox);
                    checkboxes.Add(new Point(x, y), checkBox);                                 
                }
            }
            return checkboxes;
        }
        private void CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox clicked = (CheckBox)sender;
        }
        private CheckBox GetCheckBoxAtPosition(int x, int y) {
            return checkBoxes[new Point(x, y)];
        }
