using Microsoft.EntityFrameworkCore;

namespace healthcheck.API.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Server> Servers { get; set; }
        public DbSet<UrlModel> Urls { get; set; }
    }
}