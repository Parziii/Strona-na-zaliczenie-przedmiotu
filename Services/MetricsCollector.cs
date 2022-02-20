using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strona.Services
{


    public class MetricsCollector : IMetricsCollector
    {
        private readonly List<CollectedRequestModel> _collected = new List<CollectedRequestModel>();


        public void Collect(string httpMethod, string path, int responseCode)
        {
            var collectedrequest = new CollectedRequestModel
            {
                HttpMethod = httpMethod,
                RequestUrl = path,
                ResponseCode = responseCode
            };

            _collected.Add(collectedrequest);
        }

        public IEnumerable<EndpointStats> GetEndpointStats()
        {
            throw new NotImplementedException();
        }
    }

    public class CollectedRequestModel
    {
        public string HttpMethod { get; set; }
        public string RequestUrl { get; set; }
        public int ResponseCode { get; set; }
    }

    public class EndpointStats
    {
        public string HttpMethod { get; set; }
        public string RequestUrl { get; set; }
        public int RequestsCount { get; set; }
    }
}
