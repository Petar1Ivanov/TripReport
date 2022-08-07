namespace TripReport.Data.Models
{
    public class Duration
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Value { get; set; }
        public IEnumerable<Trip> Trip { get; set; } = new List<Trip>();

    }
}
