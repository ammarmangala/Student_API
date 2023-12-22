using AutoMapper;
using Template_Web_API.Dto.Student;
using Template_Web_API.Entities;

namespace Template_Web_API.Profiles
{
    public class StudentDTOProfile : Profile
    {
        public StudentDTOProfile()
        {

            CreateMap<Student, StudentDTO>();
            CreateMap<CreateStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();

        }

    }
}
