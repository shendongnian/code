    public async Task<ObservableCollection<T>> All(string url)
        {
            ObservableCollection<T> Collection=new ObservableCollection<T>();
            try
            {
                var response = await httpclient.GetResponseAsync(url);
    
                if(!string.IsNullOrEmpty(response))
                {
                    var content  = JsonConvert.DeserializeObject<IEnumerable<T>>(response);
    
                    foreach(var item in content)
                    {
                        Collection.Add(item);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (HttpRequestException )
            {               
            }
            catch(TaskCanceledException )
            {
            }
            catch(Exception)
            {
            }
    
            //throw new NotImplementedException();
            return Collection;
    
        }
