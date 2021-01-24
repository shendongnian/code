		/// <summary>
		/// Required. A type of the metric for which data is requested.
		/// </summary>
		public Metrics MetricType { get; set; }
		[Required]
		/// <summary>
		/// Alias for MetricType.
		/// </summary>
		public string Type
		{
			get
			{
				return MetricType.ToString();
			}
			set
			{
				try
				{
					MetricType = value.ToEnum<Metrics>();
				}
				catch (System.Exception)
				{
					throw new ArgumentException("Invalid Type parameter.");
				}
			}
		}
