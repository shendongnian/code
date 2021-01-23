    Keys[] KeyboardInput = { Keys.A, Keys.S, Keys.N, Keys.M, Keys.H, Keys.F, Keys.T, Keys.G, 
                    Keys.W, Keys.Q, Keys.Z, Keys.X, Keys.Right, Keys.Left, Keys.Up, Keys.Down };
    Properties.Settings.Default.Keys = KeyboardInput;
    Properties.Settings.Default.Save();
    Keys[] keys = Properties.Settings.Default.Keys;
