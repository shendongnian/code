    public void FindWindowOrMake(string theTitle) 
    {
            var found = false;
            foreach (var openForm in Application.OpenForms.Cast<Form>()
                .Where(openForm => openForm.Text.Equals(theTitle)))
            {
                found = true;
                openForm.Activate();
                break;
            }
            if (found) return;  // target found and activated
            // create new instance
            WinMgr.Create(theTitle);
     }
