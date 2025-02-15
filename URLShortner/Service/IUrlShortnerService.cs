namespace URLShortner.Service
{
    /// <summary>
    /// Interface layer for URL service
    /// </summary>
    public interface IUrlShortnerService
    {
       /// <summary>
       /// Method which will perform the shortning of the url provided
       /// </summary>
       /// <param name="OrigionalUrl">Instance of string</param>
       /// <returns>Instance of string indicating shortned urlfor long url</returns>
        Task<string>ShortenUrlAsync(string origionalUrl);
        /// <summary>
        /// Method will return the valid long url for given short url.
        /// </summary>
        /// <param name="shortUrl">Instance of string</param>
        /// <returns></returns>
        Task<string> GetOrigionalUrlAsync(string shortUrl);
    }
}
