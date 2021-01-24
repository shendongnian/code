        private void timer1_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            _valorfechaact = now.Month <= 9 ? $"{now.Year}00{now.Month}" : $"{now.Year}0{now.Month}";
            var directory = label1.Text;
            var name = $"{_valorfechaact}.csv";
            var fullname = Path.Combine("@", directory, name);
            if (Directory.Exists(directory))
            {
                var fileInfo = new FileInfo(fullname);
                if (fileInfo.IsLocked())
                    return;
                using (var wr = new StreamWriter(fullname, true))
                {
                    wr.WriteLine("1asd" + now.Second);
                }
            }
            else
            {
                Console.WriteLine("no se puede escribir en el archivo");
                timer1.Stop();
            }
        }
