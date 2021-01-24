        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                try { this.recEngine.Dispose(); } catch (System.Exception ex) { } // Cleanup, We Don't Need to Handle Error
                components.Dispose();
            }
            base.Dispose(disposing);
        }
