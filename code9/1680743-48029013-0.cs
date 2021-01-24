    using System.Media;
    using Microsoft.Win32;
    
    public void PlayNotificationSound()
    {
        bool found = false;
        try
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\.Default\Notification.Default\.Current"))
            {
                if (key != null)
                {
                    Object o = key.GetValue(null); // pass null to get (Default)
                    if (o != null)
                    {
                        SoundPlayer theSound = new SoundPlayer((String)o);
                        theSound.Play();
                        found = true;
                    }
                }
            }
        }
        catch
        { }
        if (!found)
            SystemSounds.Beep.Play(); // consolation prize
    }
