using Template_Web_API.Dto.Student;

namespace Template_Web_API.Services
{
    public interface IStudentService 
    {
        StudentDTO GetById(int id);
        StudentDTO Create(CreateStudentDTO dto);
        StudentDTO Update(UpdateStudentDTO dto);
        bool Delete(int id);
        IEnumerable<StudentDTO> GetAll();
    }
}
