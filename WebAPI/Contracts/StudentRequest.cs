using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Contracts
{
    public class StudentRequest
    {
        public int StId { get; set; }
        public string Tckn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
    }
}
