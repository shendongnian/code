    private static void Main()
    {
    	var defaultIndex = "post";
    
    	var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
    		.DefaultIndex(defaultIndex);
    
    	var client = new ElasticClient(settings);
      	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
    	client.CreateIndex(defaultIndex, c => c
    		.Settings(s => s
    			.NumberOfShards(1)
    			.NumberOfReplicas(0)
    		)
    		.Mappings(m => m
    			.Map<PostModel>(mm => mm
    				.AutoMap()
    				.Properties(p => p
    					.Nested<Profile>(np => np
    						.Name(n => n.Profiles)
    						.AutoMap()
    					)
    				)
    			)
    		)
    	);
    	
    	var posts = new List<PostModel>
    	{
    		new PostModel
    		{
    			ProjectId = "2",
    			Language = "en",
    			PostDate = new DateTime(2017, 6, 11, 8, 39, 32, DateTimeKind.Utc),
    			Profiles = new List<Profile>
    			{
    				new Profile
    				{
    					Label = "Emotional",
    					Confidence = 1
    				}
    			}
    		},
    		new PostModel
    		{
    			ProjectId = "3",
    			Language = "en",
    			PostDate = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc),
    			Profiles = new List<Profile>
    			{
    				new Profile
    				{
    					Label = "Lazy",
    					Confidence = 3
    				}
    			}
    		},
    		new PostModel
    		{
    			ProjectId = "3",
    			Language = "en",
    			PostDate = new DateTime(2017, 6, 11, 8, 5, 1, DateTimeKind.Utc),
    			Profiles = new List<Profile>()
    		}
    	};
    	
    	client.IndexMany(posts);
    	client.Refresh(defaultIndex);
    
    	var postModels = client.Search<PostModel>(s => s
    		.Query(q =>
    		{
    			QueryContainer query = q
    				.Match(m => m
    					.Field(f => f.ProjectId)
    					.Query("3")
    				);
    
    			query = query && q
    				.Bool(b => b
    					.MustNot(bm => bm
    						.Nested(n => n
    							.Path(p => p.Profiles)
    							.Query(qn => qn
    								.Exists(m => m
    									.Field(f => f.Profiles)
    								)
    							)
    						)				
    					)			
    			);
    
    			return query;
    		}));
    }
    
    public class Profile 
    {
    	public string Label { get; set; }
    	
    	public int Confidence { get; set; }
    	
    }
    
    public class PostModel
    {
    	public string ProjectId { get; set; }
    
    	public string Language { get; set; }
    
    	public DateTime PostDate { get; set; }
    
    	public List<Profile> Profiles { get; set; }
    }
