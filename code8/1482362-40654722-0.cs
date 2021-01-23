	void Page_Load(Object sender, EventArgs e) {
		//...
		
		using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto)) {
			
			//...
			
			return bmPhoto; // <-- HERE
		}
	}
