	class LibWrapper {
	  [ThreadStatic]
	  static ClientClass _sclient;
	  public ClientClass GetClient() {
		 //std singleton stuff, with locking if needed
         (...)
		 return  _sclient;
	  }
	}
