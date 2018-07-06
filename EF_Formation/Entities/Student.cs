using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EF_Formation.Entities
{
    // http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
    public class Student
    {
        public long Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Range(5, 50)]
        public int Age { get; set; }

        // Convention 1
        public virtual Group Group1 { get; set; }

        // Convention 2
        [Required]
        public virtual Group Group2 { get; set; }

        // Convention 3
        public virtual Group Group3 { get; set; }
        public long Group3Id { get; set; }

        // Convention 4
        public virtual Group Group4 { get; set; }
        public long? Group4Id { get; set; }
    }
}