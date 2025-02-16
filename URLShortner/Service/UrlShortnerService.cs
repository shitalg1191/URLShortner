
using Microsoft.EntityFrameworkCore;
using URLShortner.Data;
using URLShortner.Model;

namespace URLShortner.Service
{
    public class UrlShortnerService : IUrlShortnerService
    {
        private UrlShortnerContext _context = new UrlShortnerContext();
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private Random _random = new Random();
        
        public async Task<string> GetOrigionalUrlAsync(string shortUrl)
        {
            var response = await _context.UrlMappings.FirstOrDefaultAsync(s => s.shortUrl == shortUrl);
            if (response == null)
            {
                return response.longUrl;
            }
            return null;
        }

        public async Task<string> ShortenUrlAsync(string origionalUrl)
        {
            var shortcode = GenerateShortcode();
            var shortUrl = "newgen.ly" + shortcode;
            var mapping = new UrlMapping();
            mapping.shortUrl = shortUrl;
            mapping.longUrl = origionalUrl;
            var response = await _context.UrlMappings.AddAsync(mapping);
            await _context.SaveChangesAsync();

            return response.Entity.shortUrl;
        }
        private string GenerateShortcode(int length = 6)
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());

        }
    }
}
