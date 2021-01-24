    namespace ProjectTest.SkickaTidRedovisningWebRef {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SkickaTidredovisningResponderBinding", Namespace="urn:shs:emottagning:SkickaTidredovisning:1:shsbp10")]
    public partial class SkickaTidredovisningResponderService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SkickaTidredovisningOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SkickaTidredovisningResponderService() {
            this.Url = global::ProjectTest.Properties.Settings.Default.Secureetime_se_SkickaTidRedovisningWebRef_SkickaTidredovisningResponderService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SkickaTidredovisningCompletedEventHandler SkickaTidredovisningCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:shs:emottagning:SkickaTidredovisningResponder:1:SkickaTidredovisning", RequestNamespace="urn:shs:emottagning:SkickaTidredovisning:1", ResponseNamespace="urn:shs:emottagning:SkickaTidredovisning:1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("tx-id")]
        public string SkickaTidredovisning(base64Binary tidredovisning, [System.Xml.Serialization.XmlElementAttribute("assistent-signatur")] SignatureType assistentsignatur, [System.Xml.Serialization.XmlElementAttribute("anordnare-signatur")] SignatureType anordnaresignatur, [System.Xml.Serialization.XmlAnyElementAttribute()] ref System.Xml.XmlElement[] Any) {
            object[] results = this.Invoke("SkickaTidredovisning", new object[] {
                        tidredovisning,
                        assistentsignatur,
                        anordnaresignatur,
                        Any});
            Any = ((System.Xml.XmlElement[])(results[1]));
            
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SkickaTidredovisningAsync(base64Binary tidredovisning, SignatureType assistentsignatur, SignatureType anordnaresignatur, System.Xml.XmlElement[] Any) {
            this.SkickaTidredovisningAsync(tidredovisning, assistentsignatur, anordnaresignatur, Any, null);
        }
        
        /// <remarks/>
        public void SkickaTidredovisningAsync(base64Binary tidredovisning, SignatureType assistentsignatur, SignatureType anordnaresignatur, System.Xml.XmlElement[] Any, object userState) {
            if ((this.SkickaTidredovisningOperationCompleted == null)) {
                this.SkickaTidredovisningOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSkickaTidredovisningOperationCompleted);
            }
            this.InvokeAsync("SkickaTidredovisning", new object[] {
                        tidredovisning,
                        assistentsignatur,
                        anordnaresignatur,
                        Any}, this.SkickaTidredovisningOperationCompleted, userState);
        }
        
        private void OnSkickaTidredovisningOperationCompleted(object arg) {
            if ((this.SkickaTidredovisningCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SkickaTidredovisningCompleted(this, new SkickaTidredovisningCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3.org/2005/05/xmlmime")]
    public partial class base64Binary {
        
        private string contentTypeField;
        
        private byte[] valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string contentType {
            get {
                return this.contentTypeField;
            }
            set {
                this.contentTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType="base64Binary")]
        public byte[] Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:shs:emottagning:SkickaTidredovisning:1")]
    public partial class SignatureType {
        
        private base64Binary signatureField;
        
        private base64Binary ocspResponseField;
        
        private System.DateTime datumForSignaturField;
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        public base64Binary signature {
            get {
                return this.signatureField;
            }
            set {
                this.signatureField = value;
            }
        }
        
        /// <remarks/>
        public base64Binary ocspResponse {
            get {
                return this.ocspResponseField;
            }
            set {
                this.ocspResponseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime datumForSignatur {
            get {
                return this.datumForSignaturField;
            }
            set {
                this.datumForSignaturField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void SkickaTidredovisningCompletedEventHandler(object sender, SkickaTidredovisningCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SkickaTidredovisningCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SkickaTidredovisningCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public System.Xml.XmlElement[] Any {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlElement[])(this.results[1]));
            }
        }
    }
    }
