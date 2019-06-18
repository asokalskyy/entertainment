namespace AtelierEntertainment
{
    public class OrderItem
    {
        /// <summary>
        /// Could we use some custom validation attributes in here for code validation? 
        /// Or validation should be moved somewhere else?
        /// </summary>
        public string Code { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}