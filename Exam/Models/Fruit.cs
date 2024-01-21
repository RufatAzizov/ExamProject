using Exam.Models.Common;

namespace Exam.Models
{
    public class Fruit : BaseEntity
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string? ImageUrl { get; set; }
    }
}
