    public class ClientApi {
        protected MultiResponse MoreThanOne { get; set; }
        // protected SingleResponse OnlyOne    { get; set; }
        protected ClientApi ( );
        public ClientApi (List<DeserializedResult> theList) {
            if (theList == null) throw ArgumentNullException("error message here");
            // add overloaded constructors to MultiResponse class.
            MoreThanOne = new MultiResponse (theList);
           // OnlyOne = null;
        }
        public ClientApi (DeserializedResult onlyOne)
            if (onlyOne == null) throw ArgumentNullException("error message here");
            MoreThanOne = new MultiResponse(onlyOne);
           // OnlyOne = onlyOne;
        }
        ///<summary>
        /// Always returns an object. The list may be empty, 
        /// but never null
        ///</summary>
        public MultiResponse GetDeHydratedJsonThingy() {
            MultiResponse HereYaGo = new MultiResponse();
          //  if (MoreThanOne !=null) HereYaGo.AddRange(MoreThanOne);
          //  if (OnlyOne != null) HereYaGo.Add(OnlyOne);
            HereYaGo.AddRange(MoreThanOne.Result);
            return HereYaGo;
        }
    }
