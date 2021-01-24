    static bool IsKeyPressed(Keys key)
        {
            if (keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Input()
        {
            keyState = Keyboard.GetState();
            if (IsKeyPressed(Keys.Space))
            {
                Cursor.X += 25;
            }
            else if (IsKeyPressed(Keys.Back))
            {
                Words.Last().RemoveLetter();
                Cursor.X -= 25;
            }
            else if (IsKeyPressed(Keys.A))
            {
                Words.Last().AddLetter(new Letter(Letters.A, Cursor));
                Cursor.X += 25;
            }
            prevKeyState = keyState;
        }
