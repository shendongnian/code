        private void ScrollRoulette()
        {
            for (int i = 0; i < fieldList.Length; i++)
            {
                fieldList[i].position.X += scrollSpeed;
                if (fieldList[i].Position.X >= scrollArea.Width + (fieldList[i].Texture.Width * 2))
                {
                    // This works now
                    fieldList[i].position.X = scrollArea.X + (fieldList[i].Position.X - (scrollArea.Width + scrollArea.X) );
                }                
            }
        }
