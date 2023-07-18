using System;
using System.ComponentModel.DataAnnotations;

namespace DoorsOpen.Models
{
    public class Userinfo
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Lastlogin { get; set; }

       
    }
}
