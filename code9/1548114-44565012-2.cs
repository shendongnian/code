    //Add an event handler on OnEnroll Event
    ZKFPEngX x = new ZKFPEngX();
    x.OnEnroll += X_OnEnroll; 
    
    
    private void X_OnEnroll(bool ActionResult, object ATemplate)
    {
        if (ActionResult)
        {
            if (x.LastQuality >= 80) //to ensure the fingerprint quality
            {
                string regTemplate = x.GetTemplateAsStringEx("9");
                File.WriteAllText(Application.StartupPath + "\\fingerprint.txt", regTemplate);
            }
            else
            {
                //Quality is too low
            }
        }
        else
        {
            //Register Failed
        }
    }
