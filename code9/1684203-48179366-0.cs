        private static class A
        {
            private static string ShowDialog(string T, string C, int AT, ComboBox copyFrom)
            {
                int WX = system.Windows.Forms.SystemInformation.WorkingArea.Width,
                    WY = system.Windows.Forms.SystemInformation.WorkingArea.Height;
                string AbilityResult = "";
                Form dialog = new Form
                {
                    Font = new System.Drawing.Font("Garamond", 15,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Pixel, ((byte)(0))),
                    FormBorderStyle = FormBorderStyle.Fixed3D,
                    Text = C,
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(WY - WY / 4, (WX - 350) / 2),
                    AutoSize = false,
                    SizeGripStyle = SizeGripStyle.Hide,
                    Owner = CardBuilder.ActiveForm,
                    ShowIcon = false,
                    ControlBox = false,
                    TopMost = true,
                    Width = 350,
                    Height = 140
                };
                ComboBox CT = new ComboBox()
                {
                    DataSource = copyFrom.DataSource,
                    Sorted = true
                };
                return Result;
            }
        }
