        private void button2_Click(object sender, EventArgs e)
        {
            var allLinesFromFile = File.ReadAllLines(_path);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = allLinesFromFile.Length;
            IDisposable subscription =
                allLinesFromFile
                    .ToObservable()
                    .SelectMany(f => Observable.Start(() => DoSomething(f)))
                    .ObserveOn(this)
                    .Do(x => progressBar1.Value += 1)
                    .Subscribe(x => { }, () =>
                    {
                        var postingComplete = MessageBox.Show("The posting is complete!", "Record Poster", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (postingComplete == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    });
        }
        private void DoSomething(string record)
        {
            System.Threading.Thread.Sleep(5);
        }
