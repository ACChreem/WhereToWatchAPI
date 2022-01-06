namespace WhereToWatch.Domains.Models
{
    public class Streaming
    {
        public Streaming() { }

        public Streaming(int id, string name , decimal amount) 
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
