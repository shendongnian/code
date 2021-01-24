	{
		"Type": "WQ",
		"Customer": "1600",
		"JobNbr": "1zAlpha - BLAHDYBLOO",
		"Delivery": 1,
		"Pickup": 1,
		"DelInst": "Location: Earth
				",
		"StartDate": "2017-02-28",
		"StartTime": "1700",
		"EndDate": "2017-03-15",
		"EndTime": "1700",
		"CustTransactionId": "555",
		"EquipmentItems": [{
				"Equipment": "0500006",
				"CatID": "050",
				"ClassID": "0006",
				"LineSeq": "1",
				"Quantity": "001"
			}, {
				"Equipment": "0500007",
				"CatID": "050",
				"ClassID": "0007",
				"LineSeq": "2",
				"Quantity": "001"
			}
		],
		"CustomerFields": {
			"blah": "12345",
			"blah blah": "123",
			"blah blah blah": "WHATEVER"
		}
	}
---
	[JsonObject]
	public partial class Reservation : IReservation
	{
		#region private fields        
		private string companyField;
		private int? locationField;
		private ReservationType typeField;
		private string customerField;
		private string custTransactionIDField;
		private Guid sbrTransactionIDField;
		private string licenseField;
		private string dlStateField;
		private string jobNbrField;
		private bool deliveryField;
		private bool pickupField;
		private string deliveryInstructionsField;
		private DateTime startDateField;
		private DateTime endDateField;
		private string customerPOField;
		private string webUserField;
		private bool rPPFlagField;
		private bool fuelFlagField;
		private decimal deliveryChargeField;
		private decimal pickupChargeField;
		private CustomerDataList customerDataField;
		private List<EquipmentItem> itemsField;
		#endregion
		#region Public properties
		/// <remarks/>
		public int? ReservationNo { get; set; }
		/// <remarks/>
		public string Company
		{
			get
			{
				return this.companyField;
			}
			set
			{
				this.companyField = value;
			}
		}
		/// <remarks/>
		public int? Location
		{
			get
			{
				return this.locationField;
			}
			set
			{
				this.locationField = (value != null) ?  value : -1;
			}
		}
		/// <remarks/>
		public ReservationType Type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}
		/// <remarks/>
		public string Customer
		{
			get
			{
				return this.customerField;
			}
			set
			{
				this.customerField = value;
			}
		}
		/// <remarks/>
		public string CustTransactionID
		{
			get
			{
				return this.custTransactionIDField != null ? custTransactionIDField : string.Empty;              
			}
			set
			{
				this.custTransactionIDField = value;
			}
		}
		/// <remarks/>
		public Guid SBRTransactionID
		{
			get
			{
				return this.sbrTransactionIDField;
			}
			set
			{
				this.sbrTransactionIDField = value;
			}
		}
		/// <remarks/>
		public string License
		{
			get
			{
				return this.licenseField;
			}
			set
			{
				this.licenseField = value;
			}
		}
		/// <remarks/>
		public string DlState
		{
			get
			{
				return this.dlStateField;
			}
			set
			{
				this.dlStateField = value;
			}
		}
		/// <remarks/>
		public string JobNbr
		{
			get
			{
				return this.jobNbrField;
			}
			set
			{
				this.jobNbrField = value;
			}
		}
		/// <remarks/>
		public bool Delivery
		{
			get
			{
				return this.deliveryField;
			}
			set
			{
				this.deliveryField = value;
			}
		}
		public bool Pickup
		{
			get
			{
				return this.pickupField;
			}
			set
			{
				this.pickupField = value;
			}
		}
		/// <remarks/>
		public string DeliveryInstructions
		{
			get
			{
				return this.deliveryInstructionsField;
			}
			set
			{
				this.deliveryInstructionsField = value;
			}
		}
		/// <remarks/>
		public System.DateTime StartDate
		{
			get
			{
				return this.startDateField;
			}
			set
			{
				this.startDateField = value;
			}
		}
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		/// <remarks/>
		public System.DateTime EndDate
		{
			get
			{
				return this.endDateField;
			}
			set
			{
				this.endDateField = value;
			}
		}
		/// <remarks/>
		public string CustomerPO
		{
			get
			{
				return this.customerPOField;
			}
			set
			{
				this.customerPOField = value;
			}
		}
		/// <remarks/>
		public string WebUser
		{
			get
			{
				return this.webUserField;
			}
			set
			{
				this.webUserField = value;
			}
		}
		/// <remarks/>
		public bool RPPFlag
		{
			get
			{
				return this.rPPFlagField;
			}
			set
			{
				this.rPPFlagField = value;
			}
		}
		/// <remarks/>
		public bool FuelFlag
		{
			get
			{
				return this.fuelFlagField;
			}
			set
			{
				this.fuelFlagField = value;
			}
		}
		/// <remarks/>
		public decimal DeliveryCharge
		{
			get
			{
				return this.deliveryChargeField;
			}
			set
			{
				this.deliveryChargeField = value;
			}
		}
		/// <remarks/>
		public decimal PickupCharge
		{
			get
			{
				return this.pickupChargeField;
			}
			set
			{
				this.pickupChargeField = value;
			}
		}
		[System.Xml.Serialization.XmlArrayItemAttribute("EquipmentItems", IsNullable = false)]
		[JsonProperty(PropertyName = "EquipmentItems")]
		public List<EquipmentItem> Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}
		/// <remarks/>
		public CustomerDataList CustomerData
		{
			get
			{
				return this.customerDataField;
			}
			set
			{
				this.customerDataField = value;
			}
		}
		List<IItemData> IReservation.Items
		{
			get
			{
				return this.itemsField.ToList<IItemData>();
			}
			set
			{
				SetItems(value);
			}
		}
		/// <remarks/>
		#endregion
		private void SetItems(List<IItemData> items)
		{            
			this.itemsField = ((List<EquipmentItem>)((IEnumerable<EquipmentItem>)items.Select(e => e.CatID == e.CatID)));
		}
	}
	#endregion  
	
	
	
	[JsonObject]
    public partial class EquipmentItem : IItemData
    {
        #region Private fields
        private string equipmentIDField;
        private string catIDField;
        private string classIDField;
        private string lineSequenceField;
        private string quantityField;
        private string toolFlexField;
        private string hourlyRateField;
        private string dailyRateField;
        private string weeklyRateField;
        private string monthlyRateField;
        private string minRateField;
        private bool daysOverField;
        private bool weeksOverField;
        private bool monthsOverField;
        #endregion
        #region Public properties
        /// <remarks/>
        public string Equipment
        {
            get
            {
                return this.equipmentIDField;
            }
            set
            {
                this.equipmentIDField = value;
            }
        }
        /// <remarks/>
        public string CatID
        {
            get
            {
                return this.catIDField;
            }
            set
            {
                this.catIDField = value;
            }
        }
        /// <remarks/>
        public string ClassID
        {
            get
            {
                return this.classIDField;
            }
            set
            {
                this.classIDField = value;
            }
        }
        /// <remarks/>
        public string LineSeq
        {
            get
            {
                return this.lineSequenceField;
            }
            set
            {
                this.lineSequenceField = value;
            }
        }
        /// <remarks/>
        public string Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }
        /// <remarks/>
        public string ToolFlex
        {
            get
            {
                return this.toolFlexField;
            }
            set
            {
                this.toolFlexField = value;
            }
        }
        /// <remarks/>
        public string HrRate
        {
            get
            {
                return this.hourlyRateField;
            }
            set
            {
                this.hourlyRateField = value;
            }
        }
        /// <remarks/>
        public string DayRate
        {
            get
            {
                return this.dailyRateField;
            }
            set
            {
                this.dailyRateField = value;
            }
        }
        /// <remarks/>
        public string WkRate
        {
            get
            {
                return this.weeklyRateField;
            }
            set
            {
                this.weeklyRateField = value;
            }
        }
        public string MinRate
        {
            get
            {
                return this.minRateField;
            }
            set
            {
                this.minRateField = value;
            }
        }
        /// <remarks/>
        public string MoRate
        {
            get
            {
                return this.monthlyRateField;
            }
            set
            {
                this.monthlyRateField = value;
            }
        }
        /// <remarks/>
        public bool DayOver
        {
            get
            {
                return this.daysOverField;
            }
            set
            {
                this.daysOverField = value;
            }
        }
        /// <remarks/>
        public bool WkOver
        {
            get
            {
                return this.weeksOverField;
            }
            set
            {
                this.weeksOverField = value;
            }
        }
        /// <remarks/>
        public bool MoOver
        {
            get
            {
                return this.monthsOverField;
            }
            set
            {
                this.monthsOverField = value;
            }
        }
        #endregion
    }
