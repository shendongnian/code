        private void Listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            try
            {
                KeyAction.PutKeyDown(e.KeyPressed);
                foreach (MacroEntree macro in macros)
                {
                    if (macro.Activated)
                        if (macro.Action != null)
                            if (macro.isMacroDown())
                            {
                                listener.OnKeyPressed -= new EventHandler<KeyPressedArgs>(Listener_OnKeyPressed);
                                new Thread(delegate ()
                                {
                                    KeyboardOperations.SendKeyUp(KeyboardOperations.KeyCode.LALT);
                                    KeyboardOperations.SendKeyUp(KeyboardOperations.KeyCode.LCONTROL);
                                    macro.ExecuteAction();
                                    Thread.Sleep(100);
                                    listener.OnKeyPressed += new EventHandler<KeyPressedArgs>(Listener_OnKeyPressed);
                                }).Start();
                            }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
