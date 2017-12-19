using DefectServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefectServer.ViewModel
{
    public class JobViewModel
    {
        public Job job { get; set; }
        public IEnumerable<SelectListItem> users { get; set; }
    }
}