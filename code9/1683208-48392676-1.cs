	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace pos.source.datasets.ProductosTableAdapters
	{
		public partial class productosTableAdapter : global::System.ComponentModel.Component
		{
			public void SetSQL(string theSQL)
			{
				this.CommandCollection[0].CommandText = theSQL;
			}
		}
	}
