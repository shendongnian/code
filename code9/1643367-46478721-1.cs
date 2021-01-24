    protected override void OnFormClosing(FormClosingEventArgs e) {
      this.Settings.dateTimePicker_Time = dateTimePicker2.Value;
      this.Settings.dateTimePicker_Checked = dateTimePicker2.Checked;
      this.Settings.Save();
      base.OnFormClosing(e);
    }
