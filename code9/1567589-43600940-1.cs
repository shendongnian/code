	private List<Autocomplete> _AutocompleteSourceCaseNumber(string query)
		{
			List<Autocomplete> sourceCaseNumbers = new List<Autocomplete>();
			try
			{
				//You will goto your Database for CasesNorm, but if will doit shorthand here
				//var results = db.CasesNorms.Where(p => p.SourceCaseNumber.Contains(query)).
				//    GroupBy(item => new { SCN = item.SourceCaseNumber }).
				//    Select(group => new { SCN = group.Key.SCN }).
				//    OrderBy(item => item.SCN).
				//    Take(10).ToList();   //take 10 is important
				CasesNorm c1 = new CasesNorm { SCN = "11111111"};
				CasesNorm c2 = new CasesNorm { SCN = "22222222"};
				IList<CasesNorm> aList = new List<CasesNorm>();
				aList.Add(c1);
				aList.Add(c2);
				var results = aList;
				foreach (var r in results)
				{
					// create objects
					Autocomplete sourceCaseNumber = new Autocomplete();
					sourceCaseNumber.Name = string.Format("{0}", r.SCN);
					sourceCaseNumber.Id = Int32.Parse(r.SCN);
					sourceCaseNumbers.Add(sourceCaseNumber);
				}
			}
			catch (EntityCommandExecutionException eceex)
			{
				if (eceex.InnerException != null)
				{
					throw eceex.InnerException;
				}
				throw;
			}
			catch
			{
				throw;
			}
			return sourceCaseNumbers;
		}
		public ActionResult AutocompleteSourceCaseNumber(string query)
		{
			return Json(_AutocompleteSourceCaseNumber(query), JsonRequestBehavior.AllowGet);
		}
		 throw;
		}
		catch
		{
			throw;
		}
		return sourceCaseNumbers;
	}
	public ActionResult AutocompleteSourceCaseNumber(string query)
	{
		return Json(_AutocompleteSourceCaseNumber(query), JsonRequestBehavior.AllowGet);
	}
