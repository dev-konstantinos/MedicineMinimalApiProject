namespace MinimalApiProject.Models
{
    public class MedicineModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Dosage { get; set; }
        public string? Description { get; set; }
        public bool IsImportant { get; set; }
        public DateOnly? ExpDate { get; set; }
        public int Quantity { get; set; }
    }
}