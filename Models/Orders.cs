namespace FitnessClub.Models
{
    public class Orders
    {
        public long Id { get; set; }
        public long ClientsId {  get; set; }
        public Clients Clients { get; set; }
        public long ServicesId { get; set; }
        public Services Services { get; set; }

    }
}
