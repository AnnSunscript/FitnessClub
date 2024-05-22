namespace FitnessClub.Models
{
    public class Services
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long TrainersId { get; set; }
        public Trainers Trainers { get; set; }
        public double Price { get; set; }
    }
}
