using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Meetup.Models;

namespace Meetup.ViewModel
{
    public class EventOldNewViewModel
    {
        public IList<Event> OldEvent { get; set; }

        public IList<Event> NewEvent { get; set; }
    }
}