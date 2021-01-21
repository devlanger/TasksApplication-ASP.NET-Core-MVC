using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApplication.Models
{
    public class CalendarDay
    {
        public List<Todo> Todoes { get; set; }
        public DateTime Date { get; set; }
    }
}
