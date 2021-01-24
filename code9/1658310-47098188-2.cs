            int BtnNum = 1;
            int BtnNumUWant = 3;
            int X = 10;
            int Y = 10;
            string pictureName = "picturepath";
            while (BtnNum < BtnNumUWant + 1)
            {
                Button Btn = new Button();
                Btn.Name = "Btn" + BtnNum.ToString();
                Btn.BackgroundImage = Image.FromFile(Path.Combine(path, pictureName + BtnNum.ToString() + ".png"));
                Btn.Location = new Point(X, Y);
                Btn.Text = Btn.Name;
                Btn.Parent = this;
                BtnNum++;
                Y += 100;
            }
