using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestAPI_processor
{
    public class clsRestAPI 
    {
        public string uURL = string.Empty;
        public string uRoute = string.Empty;

        public clsRestAPI(string URL, string route)
        {
            this.uURL = URL;
            this.uRoute = route;
        }

        public string makeRestAPI_request()
        {
            //Linking the server.
            var uClient = new RestClient(uURL);
            //Setting the request method type.
            var uRequest = new RestRequest(uRoute, Method.Get);
            //Retrieving the data using the request.
            //var uResponse1 = uClient.GetAsync(uRequest);
            var uResponse = uClient.ExecuteAsync(uRequest);
            //Reading the content of the response.
            var uContent = uResponse.GetAwaiter().GetResult();
            return uContent.get_Content();
        }
    }
}
