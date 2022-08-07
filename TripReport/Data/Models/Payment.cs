namespace TripReport.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Trip> Trip { get; set; } = new List<Trip>();
        
    }
}
