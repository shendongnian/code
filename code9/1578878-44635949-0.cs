    using BargainFinderMaxRQv310Srvc;
    using System;
    using System.IO;
    
    namespace ServicesMethods
    {
        public class BFM_v310
        {
            private BargainFinderMaxService service;
            private OTA_AirLowFareSearchRQ request;
            public OTA_AirLowFareSearchRS response;
    
            public BFM_v310(string token, string pcc, string convId, string endpoint)
            {
                //MessageHeader
                MessageHeader mHeader = new MessageHeader();
    
                PartyId[] pId = { new PartyId() };
                pId[0].Value = "SWS";
    
                From from = new From();
                from.PartyId = pId;
    
                To to = new To();
                to.PartyId = pId;
    
                mHeader.Action = "BargainFinderMaxRQ";
                mHeader.Service = new Service()
                {
                    Value = mHeader.Action
                };
                mHeader.ConversationId = convId;
                mHeader.CPAId = pcc;
                mHeader.From = from;
                mHeader.To = to;
                mHeader.MessageData = new MessageData()
                {
                    Timestamp = DateTime.UtcNow.ToString()
                };
    
                //Security
                Security security = new Security();
                security.BinarySecurityToken = token;
    
                //Service
                service = new BargainFinderMaxService();
                service.MessageHeaderValue = mHeader;
                service.SecurityValue = security;
                service.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap11;
                service.Url = endpoint;
    
                createRequest(pcc);
            }
    
            private void createRequest(string pcc)
            {
                request = new BargainFinderMaxRQv310Srvc.OTA_AirLowFareSearchRQ();
                request.AvailableFlightsOnly = true;
                request.Version = "3.1.0";
    
                request.POS = new SourceType[1];
                SourceType source = new SourceType();
    
                source.PseudoCityCode = pcc;
                source.RequestorID = new UniqueID_Type();
                source.RequestorID.ID = "1";
                source.RequestorID.Type = "1";
                source.RequestorID.CompanyName = new CompanyNameType();
                source.RequestorID.CompanyName.Code = "TN";
                source.RequestorID.CompanyName.CodeContext = "Context";
                request.POS[0] = source;
    
                OTA_AirLowFareSearchRQOriginDestinationInformation originDestination = new OTA_AirLowFareSearchRQOriginDestinationInformation();
                originDestination.OriginLocation = new OriginDestinationInformationTypeOriginLocation();
                originDestination.OriginLocation.LocationCode = "BCN";
                originDestination.DestinationLocation = new OriginDestinationInformationTypeDestinationLocation();
                originDestination.DestinationLocation.LocationCode = "MAD";
                originDestination.ItemElementName = ItemChoiceType.DepartureDateTime;
                originDestination.Item = "2017-09-10T12:00:00";
                originDestination.RPH = "1";
                request.OriginDestinationInformation = new OTA_AirLowFareSearchRQOriginDestinationInformation[1] { originDestination };
    
                request.TravelerInfoSummary = new TravelerInfoSummaryType()
                {
                    AirTravelerAvail = new TravelerInformationType[1]
                };
                request.TravelerInfoSummary.AirTravelerAvail[0] = new TravelerInformationType()
                {
                    PassengerTypeQuantity = new PassengerTypeQuantityType[1]
                };
                PassengerTypeQuantityType passenger = new PassengerTypeQuantityType()
                {
                    Quantity = "1",
                    Code = "ADT"
                };
                request.TravelerInfoSummary.AirTravelerAvail[0].PassengerTypeQuantity[0] = passenger;
    
                request.TravelerInfoSummary.PriceRequestInformation = new PriceRequestInformationType();
                request.TravelerInfoSummary.PriceRequestInformation.CurrencyCode = "USD";
                //PriceRequestInformationTypeNegotiatedFareCode nego = new PriceRequestInformationTypeNegotiatedFareCode();
                //nego.Code = "ABC";
                //request.TravelerInfoSummary.PriceRequestInformation.Items = new object[1] { nego };
                request.TPA_Extensions = new OTA_AirLowFareSearchRQTPA_Extensions();
                request.TPA_Extensions.IntelliSellTransaction = new TransactionType();
                request.TPA_Extensions.IntelliSellTransaction.RequestType = new TransactionTypeRequestType();
                request.TPA_Extensions.IntelliSellTransaction.RequestType.Name = "50ITIN";
    
                
            }
    
            public bool Execute()
            {
                response = service.BargainFinderMaxRQ(request);
    
                return response.PricedItinCount > 0;
            }
        }
    
    }
