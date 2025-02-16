using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortner.Model;
using URLShortner.Service;

namespace URLShortner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        /// <summary>
        /// Instance of IUrlShortnerService.
        /// </summary>
        private IUrlShortnerService _urlShortnerService;
        public UrlController(IUrlShortnerService urlShortnerService) 
        { 
            _urlShortnerService = urlShortnerService;
        }
        /// <summary>
        /// This will provide a short url for given long url
        /// </summary>
        /// <param name="request">Instance of GenerateShortUrlRequest</param>
        /// <returns>On completion will return the long url with valid satus code.</returns>
        [HttpPost("generateShortUrl")]
        public async Task <IActionResult> generateShortUrl( [FromBody] GenerateShortUrlRequest request)
        {
           var shortUrl = await _urlShortnerService.ShortenUrlAsync(request.longUrl);
           GenerateShortUrlResponse generateShortUrlsResponse = new GenerateShortUrlResponse();
            generateShortUrlsResponse.longUrl = request.longUrl;
            generateShortUrlsResponse.shortUrl = request.shortUrl;



            return Created(new Uri(""), generateShortUrlsResponse);
        }
        [HttpPost("getOrignalUrl")]
        public async IActionResult getOrignalUrl([FromBody] GetOrignalUrlRequest request)
        {
            var longUrlResponse = await _urlShortnerService.GetOrigionalUrlAsync(request.shortUrl);
            GetOrignalUrlResponse getOrignalUrlResponse = new GetOrignalUrlResponse();
            getOrignalUrlResponse.shortUrl = request.shortUrl;


            UrlShortnerService url = new UrlShortnerService();
            return Ok();
        }

    }
}
