﻿using Microsoft.AspNetCore.Http;
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
        /// Instance of IUrlShortenerService.
        /// </summary>
        private IUrlShortnerService _urlShortenerService;

        public UrlController(IUrlShortnerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        /// <summary>
        /// This will provide a short url for given long url.
        /// </summary>
        /// <param name="request"> Instance of GenerateShortUrlRequest</param>
        /// <returns> On completion will return the long url with valid statuscode.</returns>
        [HttpPost("generateShortUrl")]
        public async Task<IActionResult> generateShortUrl([FromBody] GenerateShortUrlRequest request)
        {

            if (string.IsNullOrEmpty(request.longUrl))
            {
                return BadRequest("the longUrl needs to be specified");
            }

            try
            {
                var shortUrl = await _urlShortenerService.ShortenUrlAsync(request.longUrl);
                GenerateShortUrlResponse generateShortUrlResponse = new GenerateShortUrlResponse();
                generateShortUrlResponse.longUrl = request.longUrl;
                generateShortUrlResponse.shortUrl = shortUrl;

                return CreatedAtAction(nameof(generateShortUrl), generateShortUrlResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Unable to process request");
            }

        }

        /// <summary>
        /// retrives the orignal URL associated with the short URL.
        /// </summary>
        /// <param name="request">Instance of GetOrignalUrlRequest containing the short URL to which find the orignal URL.</param>
        /// <returns>Response with short URL and long URL along with message if not found it will be error message.</returns>
        [HttpPost("getOrignalUrl")]
        public async Task<IActionResult> getOrignalUrl([FromBody] GetOrignalUrlRequest request)
        {
            if (string.IsNullOrEmpty(request.shortUrl))
            {
                return BadRequest("Short URL property cant be empty or null.");
            }

            try
            {
                var longUrlResponse = await _urlShortenerService.GetOriginalUrlAsync(request.shortUrl);

                GetOrignalUrlResponse getOrignalUrlResponse = new GetOrignalUrlResponse();
                getOrignalUrlResponse.shortUrl = request.shortUrl;
                getOrignalUrlResponse.longUrl = longUrlResponse;

                if (longUrlResponse == null)
                {
                    getOrignalUrlResponse.message = request.shortUrl + " is not present into the database.";
                    return NotFound(getOrignalUrlResponse);
                }
                else
                {
                    return Ok(getOrignalUrlResponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error occured while processing request." + ex.Message);
            }

        }


    }
    
}

    

