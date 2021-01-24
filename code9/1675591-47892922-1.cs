        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing && !base.Validate(true)) {
                if (this.DialogResult != DialogResult.Cancel) e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
