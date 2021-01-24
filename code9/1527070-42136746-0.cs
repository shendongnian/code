      /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class NOTIFICATION
        {
    
            private NOTIFICATIONNOTIF_HEADER nOTIF_HEADERField;
    
            private NOTIFICATIONNOTIF_BODY nOTIF_BODYField;
    
            /// <remarks/>
            public NOTIFICATIONNOTIF_HEADER NOTIF_HEADER
            {
                get
                {
                    return this.nOTIF_HEADERField;
                }
                set
                {
                    this.nOTIF_HEADERField = value;
                }
            }
    
            /// <remarks/>
            public NOTIFICATIONNOTIF_BODY NOTIF_BODY
            {
                get
                {
                    return this.nOTIF_BODYField;
                }
                set
                {
                    this.nOTIF_BODYField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class NOTIFICATIONNOTIF_HEADER
        {
    
            private string sOURCEField;
    
            private ulong mSGIDField;
    
            private string tXN_IDField;
    
            /// <remarks/>
            public string SOURCE
            {
                get
                {
                    return this.sOURCEField;
                }
                set
                {
                    this.sOURCEField = value;
                }
            }
    
            /// <remarks/>
            public ulong MSGID
            {
                get
                {
                    return this.mSGIDField;
                }
                set
                {
                    this.mSGIDField = value;
                }
            }
    
            /// <remarks/>
            public string TXN_ID
            {
                get
                {
                    return this.tXN_IDField;
                }
                set
                {
                    this.tXN_IDField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class NOTIFICATIONNOTIF_BODY
        {
    
            private NOTIFICATIONNOTIF_BODYUserDetail userDetailField;
    
            private NOTIFICATIONNOTIF_BODYCAS_Token cAS_TokenField;
    
            /// <remarks/>
            public NOTIFICATIONNOTIF_BODYUserDetail UserDetail
            {
                get
                {
                    return this.userDetailField;
                }
                set
                {
                    this.userDetailField = value;
                }
            }
    
            /// <remarks/>
            public NOTIFICATIONNOTIF_BODYCAS_Token CAS_Token
            {
                get
                {
                    return this.cAS_TokenField;
                }
                set
                {
                    this.cAS_TokenField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class NOTIFICATIONNOTIF_BODYUserDetail
        {
    
            private string uSER_NAMEField;
    
            private string uSER_EMAILField;
    
            private uint uSER_MOField;
    
            /// <remarks/>
            public string USER_NAME
            {
                get
                {
                    return this.uSER_NAMEField;
                }
                set
                {
                    this.uSER_NAMEField = value;
                }
            }
    
            /// <remarks/>
            public string USER_EMAIL
            {
                get
                {
                    return this.uSER_EMAILField;
                }
                set
                {
                    this.uSER_EMAILField = value;
                }
            }
    
            /// <remarks/>
            public uint USER_MO
            {
                get
                {
                    return this.uSER_MOField;
                }
                set
                {
                    this.uSER_MOField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class NOTIFICATIONNOTIF_BODYCAS_Token
        {
    
            private string pASSField;
    
            private string gEMALTOField;
    
            /// <remarks/>
            public string PASS
            {
                get
                {
                    return this.pASSField;
                }
                set
                {
                    this.pASSField = value;
                }
            }
    
            /// <remarks/>
            public string GEMALTO
            {
                get
                {
                    return this.gEMALTOField;
                }
                set
                {
                    this.gEMALTOField = value;
                }
            }
        }
