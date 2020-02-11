using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IStudentRepository
    {
        Task<Student> GetAsync(long id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task AddAsync(Student student);
    }
}
