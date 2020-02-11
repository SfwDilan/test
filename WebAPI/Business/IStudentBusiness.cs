using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Business
{
    public interface IStudentBusiness
    {
        Task<StudentResponse> GetAsync(long id);
        Task<StudentResponse> GetAllAsync();
        Task AddAsync(StudentRequest productRequest);
    }
}
