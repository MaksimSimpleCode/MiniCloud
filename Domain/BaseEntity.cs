using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime ModefiedOn { get; set; }
        public Guid ModefiedById { get; set; }
    }
}
