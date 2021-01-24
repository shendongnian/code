        public class gameBoard
        {
            private PictureBox _box;
            public gameBoard(PictureBox box)
            {
                _box = box;
            }
            public void drawBoard()
            {
                _box.ImageLocation = @"E:\My Data\DoCx\CS\3rd Sem\OOP\proj\images\a.png";
                _box.SizeMode = PictureBoxSizeMode.Zoom;                      
            }            
        }
