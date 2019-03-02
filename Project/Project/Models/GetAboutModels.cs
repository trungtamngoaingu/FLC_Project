using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    /// <summary>
    /// 3/2/2019 - Model About
    /// </summary>
    public class GetAboutModels
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }

        public string GetStringCreateDate
        {
            get
            {
                return CreatedDate.ToString("dd/MM/yyyy");
            }
        }
        public string GetStringModifiedDate
        {
            get
            {
                return ModifiedDate.ToString("dd/MM/yyyy");
            }
        }
    }
}