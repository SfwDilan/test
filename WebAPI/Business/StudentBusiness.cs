using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contracts;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Business
{
    public class StudentBusiness : IStudentBusiness
    {

        private readonly IStudentRepository _studentRepository;

        public StudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task AddAsync(StudentRequest studentRequest)
        {
            Student student = new Student()
            {
                StId = studentRequest.StId,
                FirstName = studentRequest.FirstName,
                LastName = studentRequest.LastName,
                Birthday = studentRequest.Birthday,
                City = studentRequest.City,
                Gender= studentRequest.Gender,
                Tckn= studentRequest.Tckn

            };
            await _studentRepository.AddAsync(student);
        }

        public async Task<StudentResponse> GetAllAsync()
        {
            StudentResponse studentResponse = new StudentResponse();
            IEnumerable<Student> students = await _studentRepository.GetAllAsync();

            if (students.ToList().Count == 0)
            {
                studentResponse.Message = "Student not found.";
            }
            else
            {
                studentResponse.Students.AddRange(students);
            }

            return studentResponse;
        }

        public async Task<StudentResponse> GetAsync(long id)
        {
            StudentResponse studentResponse = new StudentResponse();
            var student = await _studentRepository.GetAsync(id);

            if (student == null)
            {
                studentResponse.Message = "Student not found.";
            }
            else
            {
                studentResponse.Students.Add(student);
            }

            return studentResponse;
        }
    }
}
