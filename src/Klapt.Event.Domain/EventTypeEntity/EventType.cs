using Klapt.Event.Domain.Base;
using Klapt.Event.Domain.EventEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klapt.Event.Domain.EventTypeEntity
{
    public class EventType:BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<EventItem> Events { get; set; }

    }
}
