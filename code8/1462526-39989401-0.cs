        for (int i = 0; i < boxes.Count; i++)
        {
            if (player.Colliding(boxes[i]))
            {
                player.falling = false;
            }
            if (!player.Colliding(boxes[i]))
            {
                player.falling = true;
            }
        }
