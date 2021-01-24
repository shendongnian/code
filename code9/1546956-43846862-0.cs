     int scrollTo = 30;
        public void scrollDown()
        {
            this.wb.Focus();
            string result = string.Empty;
            AutoJSContext context;
            string jsScript = string.Empty;
            try
            {
                if (scrollTo > 100)
                {
                    scrollTo = 5;
                }
                context = new AutoJSContext(this.wb.Window);
                jsScript = "var x = document.getElementsByClassName('ANY_ELEMENTS_CLASS_NAME');   x[" + (scrollTo * 2) + "].scrollIntoView(); ";// CHANGE ANY_ELEMENTS_CLASS_NAME 
                context.EvaluateScript(jsScript, (nsISupports)wb.Window.DomWindow, out result);
                scrollTo += 5;
            }
            catch (Exception e)
            {
            }
        }
