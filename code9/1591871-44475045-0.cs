    /// <summary>price purchase netto</summary>
        [DefaultValue(null)]
        [JsonIgnore]
        [Validation.RequiredIf("Class", ErrorMessageResourceType = typeof(CarPlus.Base.Properties.Resources), ErrorMessageResourceName = "General_Required")]
        [Range(0, 10000000, ErrorMessageResourceType = typeof(CarPlus.Base.Properties.Resources), ErrorMessageResourceName = "ViewModelVehicle__PriceRange")]
        public decimal? PricePurchaseNetto
        {
            get
            {
                return (this.__dataModel.PricePurchaseNetto);
            }
            set
            {
                if (this.__dataModel.PricePurchaseNetto != value)
                {
                    this.__dataModel.PricePurchaseNetto = value;
                    this.RaisePropertyChanged("PricePurchaseNetto");
                    Log.Logger.DebugFormat("{0}:{1} - set('{2}')", this.FullName, MethodBase.GetCurrentMethod().Name, value == null ? "NULL" : value.ToString());
                    this.RaisePropertyChanged("PricePurchaseBrutto");
                }
            }
        }
        //-------------------------------------------------------------------------------------
        /// <summary>price purchase brutto</summary>
        [DefaultValue(null)]
        [JsonIgnore]
        [Validation.RequiredIf("Class", ErrorMessageResourceType = typeof(CarPlus.Base.Properties.Resources), ErrorMessageResourceName = "General_Required")]
        [Range(0, 10000000, ErrorMessageResourceType = typeof(CarPlus.Base.Properties.Resources), ErrorMessageResourceName = "ViewModelVehicle__PriceRange")]
        public decimal? PricePurchaseBrutto
        {
            get
            {
                return (Helpers.GetBrutto(this.__dataModel.PricePurchaseNetto, this.VatVerifiable && !this.VatImportWithout ? this.VatPurchase : null));
            }
            set
            {
                this.__dataModel.PricePurchaseNetto = Helpers.GetNetto(value, this.VatVerifiable && !this.VatImportWithout ? this.VatPurchase : null);
                this.RaisePropertyChanged("PricePurchaseNetto");
                Log.Logger.DebugFormat("{0}:{1} - set('{2}')", this.FullName, MethodBase.GetCurrentMethod().Name, value == null ? "NULL" : value.ToString());
            }
        }
