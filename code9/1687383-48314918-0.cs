            /// <devdoc>
            /// <para>Gets a <see cref='System.IO.Stream'/> that the application can use to write request data.
            ///    This property returns a stream that the calling application can write on.
            ///    This property is not settable.  Getting this property may cause the
            ///    request to be sent, if it wasn't already. Getting this property after
            ///    a request has been sent that doesn't have an entity body causes an
            ///    exception to be thrown.
            ///</para>
            /// </devdoc>
            public Stream GetRequestStream(out TransportContext context) {
