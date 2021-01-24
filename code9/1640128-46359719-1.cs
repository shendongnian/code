        private void BtnCheckStatus_Click(object sender, RoutedEventArgs e)
        {
            var fileStreamStatus = new FileStream(@"\\LBSTR\c$\temp\range.dat", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStreamStatus, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var user = new User { MachineName = "LBSTR" };
                    if (line.Equals("A"))
                        user.Status = "Close";
                    else if (line.Contains("B"))
                        user.Status = "Open";
                    
                    var existingUser = _users.FirstOrDefault(u => u.MachineName.Equals(user.MachineName));
                    if (existingUser != null)
                    {
                        existingUser.Status = user.Status;
                        return;
                    }
                    _users.Add(user);
                }
            }
        }
