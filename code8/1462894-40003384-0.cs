        public static void generateGIF()
        {
            int zoom = 1;
            int smileyID = 71;
            int goldBorder = 1;
            Console.WriteLine("Starting");
            List<Bitmap> images = new List<Bitmap>();
            Bitmap aura = new Bitmap(Image.FromFile("1511_Player_Aura.png"));
            Bitmap smilies = new Bitmap(Image.FromFile("1559_items.ItemManager_smiliesBM.png"));
            Bitmap smiley = new Bitmap(26, 26);
            
            using (Graphics gfcs = Graphics.FromImage(smiley))
            {
                Point placement = new Point(smileyID * -26, goldBorder * -26);
                gfcs.DrawImage(smilies, placement);
            }
            int i = 0;
            for (int j = 9; j < 15; j++)
            {
                Bitmap tmp = new Bitmap(64, 64);
                using (Graphics gfcs = Graphics.FromImage(tmp))
                {
                    Point placement = new Point(i * -64, j * -64);
                    gfcs.DrawImage(aura, placement);
                }
                using (Graphics gfcs = Graphics.FromImage(tmp))
                {
                    Point placement = new Point(19, 19);
                    gfcs.DrawImage(smiley, placement);
                }
                images.Add(tmp);
            }
            //GIF stuff
        }
