			...
			bool exists = false;
            bool empty = false;
 
            if (tools.ContainsKey(control)) {
                exists = true;
            }
 
            if (info == null || String.IsNullOrEmpty(info.Caption)) {
                empty = true;
            }
 
            if (exists && empty) {
                tools.Remove(control);
            }
			...
