using Microsoft.EntityFrameworkCore;
using StreamApp.API.Models;

namespace StreamApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<KursValute> KursValutes {get;set;}
        public DbSet<MyValute> MyValutes { get; set; }
    }
}