using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public  class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double DiskSpace { get; set; }
        public double UsedSpace { get; set; }
        public string? Avatar { get; set; }
        public List<string>? Files { get; set; } //Скорее всего будет ссылкой на File
    }
}
