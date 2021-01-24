        System.Diagnostics.Process proc;
        private void Btn1Click(object sender, RoutedEventArgs e)
        {
            string filename = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "nunit-console.exe");
            proc = Process.Start(filename, "/result:" + resultFile + ".xml " + fileName);
        }
        private void Btn2Click(object sender, RoutedEventArgs e)
        {
            if (proc != null)
                proc.Kill();
        }
