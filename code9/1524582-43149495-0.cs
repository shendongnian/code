        /// <summary>
        /// Returns a true or false if alert is present.
        /// </summary>
        /// <returns></returns>
        public static bool IsAlertPresent()
        {
            try
            {
                [YOUR DRIVER HERE].SwitchTo().Alert();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies if an alert is present or not.  If it is, it clicks "Accept".
        /// </summary>
        /// <param name="action"></param>
        public static void Alert()
        {
            try
            {
                if (IsAlertPresent())
                    [YOUR DRIVER HERE].SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                ///Log your errors however you must.
            }
        }
