using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class LC_Test
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "年龄")]
        public int Age { get; set; }
    }
}
