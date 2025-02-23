using System.ComponentModel.DataAnnotations;

namespace URLShortner.Model
{
        public class GenerateShortUrlRequest
        {
            /// <summary>
            /// Instance  of string representing the longUrl.
            /// </summary>
            public string longUrl { get; set; }
        }
    }
