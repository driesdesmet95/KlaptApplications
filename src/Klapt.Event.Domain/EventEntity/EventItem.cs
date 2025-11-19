using Klapt.Event.Domain.Base;
using Klapt.Event.Domain.EventDateEntity;
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

        public ICollection<EventDate> Dates { get; set; } = new List<EventDate>();
    }
}
