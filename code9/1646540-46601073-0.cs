            private Graphics g;
            
            ...
            public Box(int x, int y, int s, Form pF)
            {
                g = pF.CreateGraphics();
                ...
            }
