using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Meetup.Models;

namespace Meetup.ViewModel
{
    public class ParticipantViewModel
    {
        public Event Event { get; set; }

        public IList<ApplicationUser> Users { get; set; }

        public bool CheckRegistration { get; set; }

        public bool CheckPastEvent { get; set; }
    }
}