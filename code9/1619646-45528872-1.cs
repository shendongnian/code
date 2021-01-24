        public override void Close() {
            try {
                FlushBuffer();
                FlushEncoder();
            }
            finally {
                // Future calls to Close or Flush shouldn't write to Stream or Writer
                writeToNull = true;
 
                if ( stream != null ) {
                    try {
                        stream.Flush();
                    }
                    finally {
                        try {
                            if ( closeOutput ) {
                                stream.Close();
                            }
                        }
                        finally {
                            stream = null;
                        }
                    }
                }
            }
        }
