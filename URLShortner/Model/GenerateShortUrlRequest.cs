using System.ComponentModel.DataAnnotations;

namespace URLShortner.Model
{
    public class GenerateShortUrlRequest
    {
        /// <summary>
        /// Instance of string representing the longUrl.
        /// </summary>
        [Required]
        [MinLength(3)]
        public string longUrl {  get; set; }
        public string shortUrl { get; set; }
    }
}
