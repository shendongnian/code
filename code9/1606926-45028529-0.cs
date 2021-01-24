    using System.Threading.Tasks;
    
    private void URLValidator_DoWork(object sender, DoWorkEventArgs e)
    {
        Parallel.ForEach(urllist, (url) =>
        {
            Boolean valid = CheckURL(x);
            // Do something with the result or save it to a List/Dictionary or ...
        });
    }
