	this.FormClosing += (s, e) => {
		var result = MessageBox.Show("Exit Program?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcons.Question);
		if (result == DialogResult.No) {
			e.Cancel = true;
		} else {
			// Do some work such as closing connection with sqlite3 DB
			Application.Exit();
		}
	};
