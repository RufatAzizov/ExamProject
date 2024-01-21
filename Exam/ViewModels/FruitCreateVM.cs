namespace Exam.ViewModels
{
    public class FruitCreateVM
    {
        public IFormFile FileImage { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string? ImageUrl { get; set; }
    }
}
