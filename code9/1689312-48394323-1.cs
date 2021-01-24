        // Calls internal Serial Stream's Close() method on the internal Serial Stream.
        public void Close()
        {
            Dispose();
        }
        protected override void Dispose( bool disposing )
        {
            if( disposing ) {
                if (IsOpen) {
                    internalSerialStream.Flush();
                    internalSerialStream.Close();
                    internalSerialStream = null;
                }
            }
            base.Dispose( disposing );
        }
