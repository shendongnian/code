        public override void Close() {
            try {
                AutoCompleteAll();
            } 
            catch { // never fail
            } 
            finally {
                this.currentState = State.Closed;
                textWriter.Close();
            }
        }
