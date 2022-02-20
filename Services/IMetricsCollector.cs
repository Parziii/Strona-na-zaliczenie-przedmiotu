﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strona.Services
{
    public interface IMetricsCollector
    {
        public void Collect(string httpMethod, string path, int response);

        IEnumerable<EndpointStats> GetEndpointStats();
    }
}
