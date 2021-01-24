    namespace Helpers.Web
    {
        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.IO;
        using System.Net;
        using System.Net.Cache;
        using System.Net.Http;
        using System.Reflection;
        using System.Web;
        using Newtonsoft.Json;
        using NLog;
        public class HttpUtilities
        {
            #region NLog instance
            /// <summary>
            /// The single instance of an NLog LogManager for this class.
            /// </summary>
            private static Logger _logger = LogManager.GetCurrentClassLogger();
            #endregion
            #region Public Methods
            public static TResponse Post<TResponse, TContent>(string uri, object parameters = null, TContent content = null)
                where TContent : class
            {
                return GetResponse<TResponse, TContent>(uri, SerializeToQueryString(parameters),
                                                        content, HttpMethod.Post);
            }
            public static HttpWebResponse GetResponse<TContent>(string uri,
                                                                string parameters,
                                                                TContent content,
                                                                HttpMethod method)
                where TContent : class
            {
                // build the full URL if parameters have been specified
                if (!string.IsNullOrEmpty(parameters))
                {
                    uri += "?" + parameters;
                }
                // make the request and send back the results
                HttpWebRequest webRequest = BuildWebRequest(uri, content, method);
                return GetWebResponse(uri, webRequest);
            }
            #endregion
            #region Private Methods
            private static HttpWebRequest BuildWebRequest<TContent>(string uri, TContent content, HttpMethod method)
                where TContent : class
            {
                // get the request details
                _logger.Trace("Building request for [{0}]", uri);
                // set the web request details
                _logger.Trace("Setting request header details...");
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = method.ToString();
                webRequest.ContentType = "application/json";
                webRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                // do we have content to insert
                string serializedContent = string.Empty;
                if (content != null)
                {
                    JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                    {
                        // ignore the self referencing nature of EntityFramework objects and skip
                        // over the self references when serializing
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                    // serialize the object as json and convert it into bytes we can
                    // inject into the content stream of the request.
                    serializedContent = JsonConvert.SerializeObject(content, jsonSettings);
                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] byteContent = encoding.GetBytes(serializedContent);
                    webRequest.ContentLength = byteContent.Length;
                    // write the content
                    // NOTE: the act of writing out the data actually sends the request!
                    _logger.Trace("Sending request and getting response from [{0}]", uri);
                    using (var contentStream = webRequest.GetRequestStream())
                    {
                        contentStream.Write(byteContent, 0, byteContent.Length);
                    }
                    _logger.Trace("Injected content into request to [{0}]. Content: {1}", uri, serializedContent);
                }
                else
                {
                    // if there's no content then we haven't actually sent the request yet. However we still
                    // need to set the header details.
                    webRequest.ContentLength = 0;
                    signingHandler.AddHmacHeader(webRequest, serializedContent);
                    _logger.Trace("Sending request and getting response from [{0}]", uri);
                }
                return webRequest;
            }
            private static HttpWebResponse GetWebResponse(string uri, HttpWebRequest webRequest)
            {
                HttpWebResponse response;
                try
                {
                    _logger.Debug("Sending [{0}] request to [{1}]...", webRequest.Method, webRequest.RequestUri.AbsoluteUri);
                    response = (HttpWebResponse)webRequest.GetResponse();
                }
                catch (WebException wex)
                {
                    // we might still have response information on the request
                    // if this is so, then extract it and log it as we'll need to
                    // find out what the server actually replied with in order to debug
                    // what went on
                    _logger.Error(wex, "There was a problem getting a response from the server");
                    if (wex.Response != null)
                    {
                        try
                        {
                            // NOTE: this can be caused by the server returning a YSOD. You can see the formatted result
                            //       in debug mode by using the HTML visualizer when looking at the content of the
                            //       wResponseContent variable.
                            _logger.Debug("Attempting to extract server response details from WebException...");
                            using (Stream wResponseStream = wex.Response.GetResponseStream())
                            {
                                if (wResponseStream != null)
                                {
                                    using (StreamReader wStreamReader = new StreamReader(wResponseStream))
                                    {
                                        string wResponseContent = wStreamReader.ReadToEnd();
                                        _logger.Debug(wex, "Received fault response from [{0}]. Response: {1}",
                                            uri, wResponseContent);
                                    }
                                }
                            }
                        }
                        catch (Exception eex)
                        {
                            // there was an issue trying to get the response content from the original error.
                            // There's nothing more we can do except log this exception and rethrow the
                            // original.
                            _logger.Fatal(eex, "There was a problem getting response details from a WebException raised from the server");
                            throw;
                        }
                    }
                    else
                    {
                        _logger.Debug("No response data present in the exception.");
                    }
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "There was a problem getting a response from [{0}]", uri);
                    throw;
                }
                return response;
            }
            private static string SerializeToQueryString(object parameters)
            {
                // if we weren't given anything then there's nothing we can do
                if (parameters == null)
                {
                    return string.Empty;
                }
                if (parameters is string)
                {
                    return parameters as string;
                }
                // iterate over the parameter properties and build the query string
                Type type = parameters.GetType();
                BindingFlags flags = BindingFlags.Instance
                                     | BindingFlags.GetProperty
                                     | BindingFlags.Public;
                if (type.IsInterface)
                {
                    // if the type is an interface, only get the interface's members
                    flags |= BindingFlags.FlattenHierarchy;
                }
                PropertyInfo[] properties = type.GetProperties(flags);
                List<string> urlParameters = new List<string>();
                foreach (PropertyInfo prop in properties)
                {
                    // convert the value to a string first so that we can make it safe
                    // to put into the URL
                    _logger.Trace("Getting value from {0}.{1} [{2}]", type.FullName, prop.Name, prop.PropertyType.FullName);
                    object rawValue = prop.GetValue(parameters, null);
                    string propertyValue = string.Empty;
                    if (rawValue != null)
                    {
                        propertyValue = rawValue.ToString();
                    }
                    urlParameters.Add(string.Format("{0}={1}", prop.Name, HttpUtility.UrlEncode(propertyValue)));
                }
                return string.Join("&", urlParameters.ToArray());
            }
            #endregion
        }
    }
