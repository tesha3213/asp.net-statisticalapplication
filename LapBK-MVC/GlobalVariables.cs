using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LapBK_MVC
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();
        
        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:65280/");
            WebApiClient.DefaultRequestHeaders.Accept.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            
        }
        
    }
}