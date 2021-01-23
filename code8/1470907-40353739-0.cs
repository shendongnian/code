        /// <summary>
        /// We will start a server locally and then connect to it
        /// </summary>
        private void TestLocalCoAPServer()
        {
            /*_coapServer variable is a class level variable*/
            _coapServer = new CoAPServerChannel();
            _coapServer.CoAPRequestReceived += OnCoAPRequestReceived;
            _coapServer.Initialize(null, 5683);
        }
        /// <summary>
        /// Gets called everytime a CoAP request is received
        /// </summary>
        /// <param name="coapReq">The CoAP Request object instance</param>
        private async void OnCoAPRequestReceived(CoAPRequest coapReq)
        {
            //send ACK back
            Debug.WriteLine("Received Request::" + coapReq.ToString());
            CoAPResponse coapResp = new CoAPResponse(CoAPMessageType.ACK, CoAPMessageCode.CONTENT, coapReq);
            coapResp.AddPayload("GOT IT!");
            await _coapServer.Send(coapResp);
        }
