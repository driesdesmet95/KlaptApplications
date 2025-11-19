using Klapt.Event.Domain.Base;
using Klapt.Event.Domain.EventEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klapt.Event.Domain.EventDateEntity
{
    public class EventDate:BaseEntity
    {
        [Required]
        public Guid EventId { get; set; }
        public required EventItem Event { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}
