        private void timer1_Tick(object sender, EventArgs e)
        {
            var directory = label1.Text;
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("no se puede escribir en el archivo");
                timer1.Stop();
                return;
            }
            var now = DateTime.Now;
            _valorfechaact = now.Month <= 9 ? $"{now.Year}00{now.Month}" : $"{now.Year}0{now.Month}";
            var fullname = Path.Combine("@", directory, $"{_valorfechaact}.csv");
            var fileInfo = new FileInfo(fullname);
            if (fileInfo.IsLocked())
            {
                Console.WriteLine($"The File {fullname} is locked!");
                return;
            }
            using (var wr = new StreamWriter(fullname, true))
            {
                wr.WriteLine("1asd" + now.Second);
            }
        }
