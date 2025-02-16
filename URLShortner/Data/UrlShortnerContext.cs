using Microsoft.EntityFrameworkCore;
using URLShortner.Model;

namespace URLShortner.Data
{
    public class UrlShortnerContext: DbContext
    {
        /// <summary>
        /// Represents the UrlMappings table int the database.
        /// </summary>
        public DbSet<UrlMapping>UrlMappings { get; set; }
        /// <summary>
        /// This method configure the databse engine used for DbContext.
        /// </summary>
        /// <param name="optionsBuilder">Instance of DbContextOptionBuilder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5SU1287;Initial Catalog=Url;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }

            
        }
    }
}
