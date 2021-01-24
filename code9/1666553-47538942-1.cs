    [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ServiceModel.MessageContractAttribute(WrapperName="searchOrderResponse", WrapperNamespace="http://xml.comcast.com/nationalaccountsportal/services", IsWrapped=true)]
        internal partial class searchOrderResponse {
            
            [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://xml.comcast.com/nationalaccountsportal/services", Order=0)]
            [System.Xml.Serialization.XmlElementAttribute("searchOrderReturn")]
            public SearchOrderResponseType searchOrderReturn;
            
            public searchOrderResponse() {
            }
            
            public searchOrderResponse(SearchOrderResponseType searchOrderReturn) {
                this.searchOrderReturn = searchOrderReturn;
            }
        }
