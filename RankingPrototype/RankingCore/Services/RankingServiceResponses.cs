using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RankingCore.Services
{
    public class RankingServiceResponses
    {
        public static HttpResponseMessage PlayerDoesNotExistResponse()
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("No player found with request Id"),
                ReasonPhrase = "Player ID Not Found"
            };
        }
    }
}
