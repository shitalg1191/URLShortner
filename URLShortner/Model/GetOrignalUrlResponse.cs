namespace URLShortner.Model
{
    public class GetOrignalUrlResponse
    {
        /// <summary>
        /// This will be filled only if any error or entity not present in Db.
        /// </summary>
        public string message { get; set; }
    }
}
