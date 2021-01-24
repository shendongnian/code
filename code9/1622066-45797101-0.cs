    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.QueryParsers.Flexible.Standard;
    using Lucene.Net.QueryParsers.Flexible.Standard.Config;
    using Lucene.Net.Search;
    using Lucene.Net.Store;
    using Lucene.Net.Support;
    using Lucene.Net.Util;
    using System;
    using System.Globalization;
    
    /*
    Package Manager:
    Install-Package Lucene.Net -Version 4.8.0-beta00004 -Pre
    Install-Package Lucene.Net.Analysis.Common -Version 4.8.0-beta00004 -Pre
    Install-Package Lucene.Net.QueryParser -Version 4.8.0-beta00004 -Pre
    */
    
    namespace LuceneNetNumbers
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			LuceneVersion MatchVersion = LuceneVersion.LUCENE_48;
    
    			using (var oDirectory = new RAMDirectory())
    			{
    				var oAnalyzer = new StandardAnalyzer(MatchVersion);
    
    				//##########
    				//##########
    
    				//List of changes...
    
    				//1. Remove this.
    				//var oQueryParser = new MultiFieldQueryParser(MatchVersion, new[] { "name", "height", "age" }, oAnalyzer);
    
    				//2. Add the following 6 lines of code.
    				var oQueryParser = new StandardQueryParser(oAnalyzer);
    
    				var oNumericConfigMap = new HashMap<string, NumericConfig>();
    				oNumericConfigMap.Put("height", new NumericConfig(8, new NumberFormatIgnoreExceptions(CultureInfo.CurrentCulture), NumericType.INT32));
    				oNumericConfigMap.Put("age", new NumericConfig(8, new NumberFormatIgnoreExceptions(CultureInfo.CurrentCulture), NumericType.DOUBLE));
    				oQueryParser.NumericConfigMap = oNumericConfigMap;
    
    				oQueryParser.SetMultiFields(new[] { "name", "height", "age" });
    
    				//3. Add null as second parameter to StandardQueryParser.Parse below to utilize StandardQueryParser.SetMultiFields
    
    				//4. Create NumberFormatIgnoreExceptions. I was not able to find another way (yet) to get 
    				//StandardQueryParser.SetMultiFields and StandardQueryParser.NumericConfigMap to work with 
    				//both text and number fields.  I feel like this is a bit of a hack, but it does satisfiy my
    				//requirement of using a query parser to search for numbers (and text... implied by example).
    
    				//##########
    				//##########
    
    				var oIndexWriterConfig = new IndexWriterConfig(MatchVersion, oAnalyzer);
    				var oIndexWriter = new IndexWriter(oDirectory, oIndexWriterConfig);
    				var oSearcherManager = new SearcherManager(oIndexWriter, true, null);
    
    				var oAdd = new Action<string, double, int>((sName, nAge, nHeight) =>
    				{
    					var oDocument = new Document
    					{
    						new TextField("name", sName, Field.Store.YES),
    						new Int32Field("height", nHeight, Field.Store.YES),
    						new DoubleField("age", nAge, Field.Store.YES),
    					};
    
    					oIndexWriter.UpdateDocument(new Term("name", sName), oDocument);
    				});
    
    				oAdd("John Doe", 24.45, 56);
    				oAdd("John Smith", 44.44, 64);
    				oAdd("Mike Smith", 56.65, 70);
    
    				oIndexWriter.Flush(true, true);
    				oIndexWriter.Commit();
    
    				//
    
    				var oSearch = new Action<string>((sQueryString) =>
    				{
    					var oQuery = oQueryParser.Parse(sQueryString, null);
    					oSearcherManager.MaybeRefreshBlocking();
    					var oSearcher = oSearcherManager.Acquire();
    
    					try
    					{
    						var oTopDocs = oSearcher.Search(oQuery, 10);
    						var nTotalHits = oTopDocs.TotalHits;
    						Console.WriteLine("Total Hits: {0}", nTotalHits);
    
    						foreach (var oResult in oTopDocs.ScoreDocs)
    						{
    							var oDocument = oSearcher.Doc(oResult.Doc);
    
    							var nScore = oResult.Score;
    							var sName = oDocument.GetField("name")?.GetStringValue();
    							var nAge = oDocument.GetField("age")?.GetNumericValue();
    							var nHeight = oDocument.GetField("height")?.GetNumericValue();
    
    							Console.WriteLine("{0:0.00}, {1,15}, {2,8}, {3,8}", nScore, sName, nAge, nHeight);
    						}
    					}
    					catch (Exception e)
    					{
    						Console.WriteLine(e.ToString());
    					}
    					finally
    					{
    						oSearcherManager.Release(oSearcher);
    						oSearcher = null;
    					}
    				});
    
    				oSearch("john");
    				oSearch("height:64");
    				oSearch("age:[44.45 TO 56.66]");
    				oSearch("height:[70 TO *]");
    
    				/*
                    Output:
    				Total Hits: 2
    				0.12,        John Doe,    24.45,       56
    				0.12,      John Smith,    44.44,       64
    				Total Hits: 1
    				1.00,      John Smith,    44.44,       64
    				Total Hits: 1
    				1.00,      Mike Smith,    56.65,       70
    				Total Hits: 1
    				1.00,      Mike Smith,    56.65,       70
                    */
    			}
    		}
    	}
    
    	class NumberFormatIgnoreExceptions : NumberFormat
    	{
    		public NumberFormatIgnoreExceptions(CultureInfo locale) : base(locale)
    		{
    		}
    
    		public override object Parse(string source)
    		{
    			var oValue = default(object);
    
    			try { oValue = base.Parse(source); } catch { }
    
    			return oValue;
    		}
    	}
    }
