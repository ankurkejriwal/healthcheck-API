using healthcheck.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;

namespace healthcheck.API
{
    public class HelperMethods
    {

        TimingClient client = new TimingClient();
       
        public async Task<IEnumerable<ResponseTimeModel>>GetResponsesInParallelFixed(IEnumerable<string> urls)
        {
            var urlTimings = new List<ResponseTimeModel>();
            var batchSize = 100;
            int numberOfBatches = (int)Math.Ceiling((double)urls.Count() / batchSize);

            for (int i = 0; i < numberOfBatches; i++)
            {
                var currentUrls = urls.Skip(i * batchSize).Take(batchSize);
                var tasks = currentUrls.Select(url => client.GetHttpWithTiming(url));
                urlTimings.AddRange(await Task.WhenAll(tasks));
            }

            return urlTimings;
        }


    }
}


    
