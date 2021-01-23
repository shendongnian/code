    case "down":
                if (rotation != "down")
                {
                    rotation = "down";
                    pb_sprite.ImageLocation = null;
                    pb_sprite.ImageLocation = @"Images/tenk.png";
                    pb_sprite.Load();
                    pb_sprite.Image.RotateFlip((RotateFlipType.Rotate180FlipNone));
                }
                break;
