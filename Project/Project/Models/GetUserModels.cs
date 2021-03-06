﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class GetUserModels
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long GroupId { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
        public string GroupName { get; set; }
    }
}