﻿using Exam.Models.Common;

namespace Exam.Models
{
    public class AppUser : BaseEntity
    {
       public string Email { get; set; }
       public string UserName { get; set; }
       public string Name { get; set; }
       public string Surname { get; set; }
        
    }
}
