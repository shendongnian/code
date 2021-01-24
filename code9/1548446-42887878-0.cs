    if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                               imgBootFlashState.Image = Properties.Resources.locked;
                               helpBootState.Image = Properties.Resources.help_boot_flash_disabled; 
                            }));
                        }
                        else
                        {
                            imgBootFlashState.Image = Properties.Resources.locked;
                            helpBootState.Image = Properties.Resources.help_boot_flash_disabled;
                        }
        }
