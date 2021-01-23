    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace bifrost
    {
        public class AwsSigningHelper
        {
            private const string Service = "execute-api";
            public static readonly StringContent EmptyContent = new StringContent("", Encoding.UTF8, "application/json");
            public const string Iso8601DateTimeFormat = "yyyyMMddTHHmmssZ";
            public const string Iso8601DateFormat = "yyyyMMdd";
    
            private static string GetHost(string url)
            {
                Regex reg = new Regex(@"https\:\/\/([a-z|0-9|A-Z]+\.execute-api\.[a-z|A-Z|0-9|-]+.amazonaws\.com).*");
    
                Match match = reg.Match(url);
    
                Console.WriteLine("host: " + match.Groups[1].Value);
    
                return match.Groups[1].Value;
            }
    
            public static HttpRequestMessage GenerateAwsSignedGetRequest(string endpointUrl, string awsRegion, string accessKeyId, string secretAccessKey, string sessionToken)
            {
                return GenerateAwsSignedRequest(HttpMethod.Get, endpointUrl, EmptyContent,
                    awsRegion, accessKeyId, secretAccessKey, sessionToken);
            }
    
            public static HttpRequestMessage GenerateAwsSignedGetRequest(string endpointUrl, string awsRegion, string accessKeyId, string secretAccessKey)
            {
                return GenerateAwsSignedRequest(HttpMethod.Get, endpointUrl, EmptyContent,
                    awsRegion, accessKeyId, secretAccessKey, null);
            }
    
            public static HttpRequestMessage GenerateAwsSignedPostRequest(string endpointUrl, HttpContent content, string awsRegion, string accessKeyId, string secretAccessKey, string sessionToken)
            {
                return GenerateAwsSignedRequest(HttpMethod.Post, endpointUrl, content,
                    awsRegion, accessKeyId, secretAccessKey, sessionToken);
            }
    
            public static HttpRequestMessage GenerateAwsSignedPostRequest(string endpointUrl, HttpContent content, string awsRegion, string accessKeyId, string secretAccessKey)
            {
                return GenerateAwsSignedRequest(HttpMethod.Post, endpointUrl, content,
                    awsRegion, accessKeyId, secretAccessKey, null);
            }
    
            public static HttpRequestMessage GenerateAwsSignedPutRequest(string endpointUrl, HttpContent content, string awsRegion, string accessKeyId, string secretAccessKey, string sessionToken)
            {
                return GenerateAwsSignedRequest(HttpMethod.Put, endpointUrl, content,
                    awsRegion, accessKeyId, secretAccessKey, sessionToken);
            }
    
            public static HttpRequestMessage GenerateAwsSignedPutRequest(string endpointUrl, HttpContent content, string awsRegion, string accessKeyId, string secretAccessKey)
            {
                return GenerateAwsSignedRequest(HttpMethod.Put, endpointUrl, content,
                    awsRegion, accessKeyId, secretAccessKey, null);
            }
    
            private static string CreateAuthorizationHeader(string awsAccessKey, string signature, string signedHeaders, string dateStamp, string region, string serviceName)
            {
                return String.Format("AWS4-HMAC-SHA256 Credential={0}/{1}/{2}/{3}/aws4_request, SignedHeaders={4}, Signature={5}",
                    awsAccessKey, dateStamp, region, serviceName, signedHeaders, signature);
            }
    
            private static HttpRequestMessage GenerateAwsSignedRequest(HttpMethod method, string endpointUrl, HttpContent content, string awsRegion, string accessKeyId, string secretAccessKey, string sessionToken)
            {
    
                DateTime now = DateTime.UtcNow;
                HttpRequestMessage httpRequest = new HttpRequestMessage(method, endpointUrl);
                httpRequest.Headers.Add("host", GetHost(endpointUrl));
                httpRequest.Headers.Add("x-amz-date", now.ToString(Iso8601DateTimeFormat));
                httpRequest.Content = content;
    
                List<string> signHeadersList = new List<string>
                {
                        "content-type",
                        "host",
                        "x-amz-date",
                };
    
                if (!string.IsNullOrWhiteSpace(sessionToken))
                {
                    signHeadersList.Add("x-amz-security-token");
                    httpRequest.Headers.Add("x-amz-security-token", sessionToken);
                }
    
                string[] signedHeaders = signHeadersList.ToArray();
    
                string signedHeadersString = string.Join(";",
                    signedHeaders.Select(x => x.Trim().ToLowerInvariant()).OrderBy(x => x));
    
                AwsV4SignatureCalculator signatureCalculator = new AwsV4SignatureCalculator(secretAccessKey, Service, awsRegion);
                string signature = signatureCalculator.CalculateSignature(httpRequest, signedHeaders, now);
    
                string authorization = CreateAuthorizationHeader(accessKeyId, signature,
                    signedHeadersString, now.ToString(Iso8601DateFormat), awsRegion, Service);
    
                httpRequest.Headers.TryAddWithoutValidation("Authorization", authorization);
    
                return httpRequest;
            }
        }
    }
