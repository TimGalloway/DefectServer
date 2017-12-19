using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DefectServer.Models
{
    public class Job : BaseModel
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        public Int32? UserId { get; set; }
        public User JobUser { get; set; }
        public String Reference { get; set; }

        public ICollection<Defect> Defects { get; set; }
    }
}