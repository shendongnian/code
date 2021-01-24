    public int[] Product_Update(Sintra.ScannetWebService.ProductUpdate ProductData) {
                Sintra.ScannetWebService.Product_UpdateRequest inValue = new Sintra.ScannetWebService.Product_UpdateRequest();
                inValue.ProductData = ProductData;
                Sintra.ScannetWebService.Product_UpdateResponse retVal = ((Sintra.ScannetWebService.WebServicePort)(this)).Product_Update(inValue);
                return retVal.Product_UpdateResult;
            } 
