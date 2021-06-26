using System.Collections.Generic;
using System.Linq;
using healthcheck.API.Models;

namespace healthcheck.Api{
    public class DataSeed{

        private readonly ApiContext _ctx;
        
        public DataSeed(ApiContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedData(int nServers, int nUsers){
            if(!_ctx.Servers.Any()){
                SeedServers(nUsers);
            }
            if(!_ctx.Urls.Any()){
                SeedUrls(nServers);
            }
            _ctx.SaveChanges();

        }

        private void SeedServers(int n){
            List<Server> servers = BuildServerList();

            foreach(var server in servers){
                _ctx.Servers.Add(server);
            }  
        }


         private void SeedUrls(int n){
            List<UrlModel> urls = BuildUrlList();

            foreach(var url in urls){
                _ctx.Urls.Add(url);
            }  
        }

        private List<Server> BuildServerList(){
            
            List<Server> servers = new List<Server>();

            var ServerSeed = new List<string>{"uapvvp11","uapvvp11","uapwsp11","uapwsp14"};

            for(int i = 0; i<=ServerSeed.Count(); i++){
                servers.Add(new Server{
                    Id = i,
                    Name = ServerSeed[i]
                });
            }

            return servers;
        }

        private List<UrlModel> BuildUrlList(){
            
            List<UrlModel> urls = new List<UrlModel>();

            var UrlSeed = new List<string>{"silver-lu.rbcgam.com","silver.rbcadvisorservices.com","silver.rbcsfc.com","silver.rbc.com"};

            for(int i = 0; i<=UrlSeed.Count(); i++){
                urls.Add(new UrlModel{
                    Id = i,
                    ServerName = "uapvvp11",
                    URL = UrlSeed[i]
                });
            }

            return urls;
        }


    }
}