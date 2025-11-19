using Klapt.Event.Domain.Base;
using Klapt.Event.Domain.EventDateEntity;
using Klapt.Event.Domain.EventTypeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klapt.Event.Domain.EventEntity
{
    public class EventItem:BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public Guid? EventTypeId { get; set; }

        public ICollection<EventDate> Dates { get; set; } = new List<EventDate>();
        public EventType? Type { get; set; }
    }
}
