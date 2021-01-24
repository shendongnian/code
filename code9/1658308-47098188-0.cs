            int BtnNum = 1;
            int BtnNumUWant = 3;
            string pictureName = "picturepath";
            while (BtnNum < BtnNumUWant)
            {
                Button Btn = new Button();
                Btn.Name = "Btn" + BtnNum;
                Btn.BackgroundImage = Image.FromFile(Path.Combine(path, pictureName + BtnNum.ToString() + ".png"));
                BtnNum++;
            }
