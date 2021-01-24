    private void button1_Click(object sender, EventArgs e)
    {
        new Task(() => RunCommand()).Start();
    }
    private void RunCommand()
    {
        var host = "hostname";
        var username = "username";
        var password = "password";
        using (var client = new SshClient(host, username, password))
        {
            client.Connect();
            var cmd = client.CreateCommand("command1; command2");
            var result = cmd.BeginExecute();
            using (var reader =
                       new StreamReader(cmd.OutputStream, Encoding.UTF8, true, 1024, true))
            {
                while (!result.IsCompleted || !reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        textBox1.Invoke(
                            (MethodInvoker)(() =>
                                textBox1.AppendText(line + Environment.NewLine)));
                    }
                }
            }
            cmd.EndExecute(result);
        }
    }
