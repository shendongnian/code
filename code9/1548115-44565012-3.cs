    private void X_OnCapture(bool ActionResult, object ATemplate)
    {
        if (ActionResult) //if fingerprint is captured successfully
        {
            bool ARegFeatureChanged = true;
            string regTemplate = File.ReadAllText(Application.StartupPath + "\\fingerprint.txt");
            string verTemplate = x.GetTemplateAsString();
            bool result = x.VerFingerFromStr(regTemplate , verTemplate, false, ARegFeatureChanged);
            if (result)
            {
                //matched
            }
            else
            {
                //not matched
            }
        } 
        else
        {
            //failed to capture a valid fingerprint
        }
    }
