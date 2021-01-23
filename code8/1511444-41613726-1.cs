    for(int x = 0; x < W; x++)
    {
        for(int y = 0; y < H; y++)
        {
            Button btn = ParentPanel.Controls.OfType<Button>().FirstOrDefault(ctrl => ctrl.Name == "button_" + x.ToString() + "_" + y.ToString());
            if(btn != null)
            {
                // depending on if arr[x][y] == 1 make your action
            }
        }
    }
