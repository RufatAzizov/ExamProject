namespace Exam.ViewModels
{
    public class FruitUpdateVM
    {
        public int Id { get; set; }
        public IFormFile FileImage { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string? ImageUrl { get; set; }
    }
}
