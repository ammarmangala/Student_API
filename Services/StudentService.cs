using AutoMapper;
using Template_Web_API.Dto.Student;
using Template_Web_API.Entities;
using Template_Web_API.Repositories.Base;

namespace Template_Web_API.Services
{
    public class StudentService : IStudentService
    {
        private IRepository<Student> _studentRepository;
        private IMapper _mapper;

        public StudentService(IRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        // This method creates a new student based on the provided DTO and saves it to the repository
        public StudentDTO Create(CreateStudentDTO dto)
        {
            //Student student = new Student()
            //{
            //    FirstName = dto.FirstName,
            //    LastName = dto.LastName,
            //    RNumber = dto.RNumber,
            //    BirthDate = dto.BirthDate
            //};

            Student student = _mapper.Map<Student>(dto);

            _studentRepository.Add(student);
            _studentRepository.SaveChanges();

            StudentDTO result = _mapper.Map<StudentDTO>(student);
            return result;
        }

        public bool Delete(int id)
        {
            Student toDelete = _studentRepository.GetById(id);
            if (toDelete == null)
            {
                return false;
            }

            _studentRepository.Delete(toDelete);
            _studentRepository.SaveChanges();

            return true;
            // This method deletes a student with the specified ID from the repository
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            return _studentRepository.GetAll().Select(_mapper.Map<StudentDTO>);
        }

        public StudentDTO GetById(int id)
        {
            Student student = _studentRepository.GetById(id);
            if (student == null)
            {
                return null;
            }

            return _mapper.Map<StudentDTO>(student);
            // This method retrieves a student with the specified ID from the repository
        }

        public StudentDTO Update(UpdateStudentDTO dto)
        {
            Student toUpdate = _studentRepository.GetById(dto.Id);

            if (toUpdate == null)
            {
                return null;
            }

            toUpdate = _mapper.Map(dto, toUpdate);

            //toUpdate.FirstName = dto.FirstName;
            //toUpdate.LastName = dto.LastName;
            //toUpdate.RNumber = dto.RNumber;
            //toUpdate.BirthDate = dto.BirthDate;

            _studentRepository.Update(toUpdate);
            _studentRepository.SaveChanges();

            return _mapper.Map<StudentDTO>(toUpdate);
        }

        //private StudentDTO ConvertToDto(Student student)
        //{
        //    StudentDTO dto = new StudentDTO()
        //    {
        //        Id = student.Id,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName,
        //        RNumber = student.RNumber,
        //        BirthDate = student.BirthDate
        //    };

        //    return dto;
        //}
    }
}
