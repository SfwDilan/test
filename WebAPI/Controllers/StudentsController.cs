using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business;
using WebAPI.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentBusiness _studentBusiness;

        public StudentsController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        // GET api/students/{id}
        [HttpGet("{id}")]
        public async Task<StudentResponse> Get(long id)
        {
            return await _studentBusiness.GetAsync(id);
        }

        // GET api/students
        [HttpGet]
        public async Task<StudentResponse> Get()
        {
            return await _studentBusiness.GetAllAsync();
        }

        // POST api/students
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task Post([FromBody]StudentRequest studentRequest)
        {
            await _studentBusiness.AddAsync(studentRequest);
        }
    }
}