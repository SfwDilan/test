using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Contracts
{
    public class StudentResponse
    {
        public StudentResponse()
        {
            Students= new List<Student>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Student> Students { get; set; }
    }
}
