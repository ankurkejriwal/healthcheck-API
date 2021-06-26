using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using healthcheck.API.Models;

public class TimingClient
    {
   
         private HttpClient client;

        public TimingClient()
        {
            client = new HttpClient();
        }
        public async Task<ResponseTimeModel> GetHttpWithTiming(string URL)
        {
            var timer = Stopwatch.StartNew();
            var result = await client.GetAsync(URL);
            var interimValue = new Tuple<HttpResponseMessage, TimeSpan>(result, timer.Elapsed);

            return new ResponseTimeModel{
                ResponseCode = result.StatusCode.ToString(),
                ResponseTime = timer.Elapsed.TotalSeconds
                
            };
        }
    }
