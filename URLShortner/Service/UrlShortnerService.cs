
using URLShortner.Model;

namespace URLShortner.Service
{
    public class UrlShortnerService : IUrlShortnerService
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private Random _random = new Random();
        public Task<string> GetOrigionalUrlAsync(string shortcode)
        {
            throw new NotImplementedException();
        }

        public Task<string> ShortenUrlAsync(string origionalUrl)
        {
            var shortcode = GenerateShortcode();
            var shortUrl = "newgen.ly" + shortcode;
            var mapping = new UrlMapping();
            mapping.shortUrl = shortUrl;
            mapping.longUrl = origionalUrl;
            throw new NotImplementedException();
        }
        private string GenerateShortcode(int length = 6)
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());

        }
    }
}
