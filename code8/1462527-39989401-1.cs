    var isFalling=true;  // assume the worst
    for (int i = 0; i < boxes.Count; i++)
        {
            if (player.Colliding(boxes[i]))
            {
                isFalling = false;
                break;
            }
        }
    player.falling = isFalling;
