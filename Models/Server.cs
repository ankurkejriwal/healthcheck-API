namespace healthcheck.API.Models
{
    public class Server{
        public string Id {get; set;}
        public string Name {get; set;}
        public bool IsOnline {get; set;}
        public int ResponseTime {get; set;}
        public string ResponseUnits {get; set;}
        public string ResponseCode{get;set;}

    }
}