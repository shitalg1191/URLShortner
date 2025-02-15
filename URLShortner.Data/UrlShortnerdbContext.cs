using Microsoft.EntityFrameworkCore;
using URLShortner.Model;

namespace URLShortner.Data
{
    public class UrlShortnerdbContext : DbContext
    {
        public DbSet<ShortUrl>ShortUrls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string url = "Data Source=DESKTOP-5SU1287;Initial Catalog=Url;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(url);
            }
        }

    }
}
