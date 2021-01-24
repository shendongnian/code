            int BtnNum = 1;
            int BtnNumUWant = 3;
            int X = 10;
            int Y = 10;
            string pictureName = "picturepath";
            while (BtnNum < BtnNumUWant)
            {
                Button Btn = new Button();
                Btn.Name = "Btn" + BtnNum;
                Btn.BackgroundImage = Image.FromFile(Path.Combine(path, pictureName + BtnNum.ToString() + ".png"));
                Btn.Location = new Point(X, Y);
                Btn.Text = Btn.Name;
                Btn.Parent = this;
                BtnNum++;
                Y += 10;
            }
