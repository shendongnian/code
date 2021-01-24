    farmSwitch.Toggled += (object sender, ToggledEventArgs e) => {
                if(HasBeenProgrammaticallyToggled)
                {
                     //This has been toggled programmatically, so reset our bool
                     HasBeenProgrammaticallyToggled = false;
                }
                else
                {
                     // I am assuming this is what you use to determine a manual toggle?
                     manualOnFarm = true;
                }
                
                Console.WriteLine("Switch.Toggled event sent");
                changeOnFarmStatus(e);
            };
