                const string baseName = "textBox";
                var names = Enumerable.Range(1, 10).Select(x => baseName + x.ToString()).ToList();
    
                var tbxs = names.Select(name => this.Controls.Find(name, true).FirstOrDefault()).Where(x=> x != null).ToList();
                foreach (var txt in tbxs) {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        txt.Text = "EMPTY";
                    }
                }
