           private void DrawRegion_MouseClick(object sender,MouseEventArgs e)
            {
                if (re.Contains(e.Location))
                    Mouse_Down = true;
                else
                    Mouse_Down = false;    
            }
