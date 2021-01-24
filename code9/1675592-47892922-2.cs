        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.Cancel) {
                if (!base.Validate(true)) e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
