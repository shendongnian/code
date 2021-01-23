			foreach( var i in TransmittedDataBLL.Instance.GetDepEdTextFile( data ) )
			{
				writer.WriteLine( GetCSV( i ) );
			}
		}
		protected string GetCSV( DepEdTextFile i )
		{
			string[] list = new string[]
			{
				i.Region.ToString(),
				i.Division.ToString(),
				i.Station.ToString(),
				i.EmployeeNumber.ToString(),
				i.FirstName,
				i.MiddleInitial,
				i.LastName,
				i.Appelation.ToString(),
				i.DednCode.ToString(),
				i.DednSubCode.ToString(),
				i.EffectDate.ToString(),
				i.TermDate.ToString(),
				i.AmountStr,
				i.LoanAmountStr,
				i.InterestAmountStr,
				i.OtherChargesStr,
				i.BillingType.ToString(),
				i.UpdateCode.ToString()
			};
				
			string csvLine = "\"" + string.Join( @"","", list ) + "\"";
			return csvLine;
		}
