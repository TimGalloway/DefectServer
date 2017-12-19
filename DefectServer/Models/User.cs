using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefectServer.Models
{
    public class User : BaseModel
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String SurName { get; set; }
        public String Email { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}