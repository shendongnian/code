    void Main()
    {
    	string jsonText1 = "{\"data\":[{\"geo\":{\"lat\":-7.328805,\"lng\":112.696606},\"id\":337417,\"title\":\"Omapukis, UD\",\"address\":\"Kebraon Manis Barat BJ/01, Surabaya, Jawa Timur, 60222, Indonesia\",\"phone\":\"+6285748393379\",\"rating\":5,\"classifieds\":[],\"image_url\":\"http://indonesia-product.com/custom/domain_1/image_files/sitemgr_photo_1303.jpg\",\"type\":\"listing\"},{\"id\":8,\"title\":\"Traditional Food Pukis, Surabaya SME Goes To Online\",\"author\":\"\",\"publication_date\":\"2017-04-11T00:00:00+0700\",\"rating\":0,\"image_url\":\"http://indonesia-product.com/custom/domain_1/image_files/sitemgr_photo_1267.jpg\",\"type\":\"article\"}]}";
        
    	var wrapper = JsonConvert.DeserializeObject<Wrapper>(jsonText1);
    	
    	// print wrapper object
    }
    
    public class Wrapper
    {
    	public List<Data> data { get; set;}
    }
    
    public class Data
    {
    	public Geo geo { get; set;}
    
    	public int Id { get; set;}
    	
    	public string Title { get; set;}
    	
    	public string Address { get; set;}
    	
    	public string Phone { get; set;}
    	
    	public int Rating { get; set;}
    	
    	public string ImageUrl { get; set;}
    	
    	public string Type { get; set;}
    }
    
    public class Geo
    {
    	public double lat { get; set;}
    	
    	public double lng { get; set;}
    }
