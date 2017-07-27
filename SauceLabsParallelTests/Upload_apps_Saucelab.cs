//using RestSharp;
//using RestSharp.Authenticators;
//using System;

//namespace SauceLabsParallelTests
//{
//    public  class Upload_apps_Saucelab
//    {
//        // Uploads a file to Sauce Temporary Storage via REST API using the
//        // RestSharp library. Be sure to replace the string values for
//        // FileName, FilePath, UserName, and AccessKey.

//        static void Main(string[] args)
//        {
//            string FileName = "com.facebook.lite_v47.0.0.6.68-62148578_Android-2.3"; 
//            string FilePath = @"C:\library"; 
//            string UserName = "kamarulhilmi"; 
//            string AccessKey = "8bae2123-3ddd-43b4-ae01-47fb4a2cfc60"; 

//            var client = new RestClient("https://saucelabs.com/rest/v1/");
//            client.Authenticator = new HttpBasicAuthenticator(UserName, AccessKey);
//            var request = new RestRequest("storage/" + UserName + "/" + FileName + "?overwrite=true", Method.POST);
//            request.AddHeader("Content-Type", "application/octet-stream");
//            request.AddFile(FileName, FilePath);
//            var result = client.Execute(request);
//            Console.WriteLine(result.Content);
//        }
//    }
//}