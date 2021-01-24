        public void readWeightStatusThread()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                string readStatus = (string)txtD6010Status.Invoke(new Func<string>(() => txtD6010Status.Text));
                MessageBox.Show(readStatus);
            }
        }
