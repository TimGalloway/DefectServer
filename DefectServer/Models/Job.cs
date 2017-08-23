using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefectServer.Models
{
    public class Job : BaseModel
    {
        public Int32 Id { get; set; }
        public String Description { get; set; }

        public ICollection<Defect> Defects { get; set; }
    }
}