using Template_Web_API.Entities.Base;

namespace Template_Web_API.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
