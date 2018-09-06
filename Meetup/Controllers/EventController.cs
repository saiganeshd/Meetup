using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meetup.Models;
using Meetup.ViewModel;
using Microsoft.AspNet.Identity;

namespace Meetup.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private ApplicationDbContext db;

        public EventController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult Index()
        {
            List<Event> events = db.Events.ToList();
            IList<Event> oldEvents = new List<Event>();
            IList<Event> newEvents = new List<Event>();
            foreach (var eve in events)
            {
                int res = DateTime.Compare(eve.EventDate, DateTime.Now);
                if (res < 0)
                {
                    oldEvents.Add(eve);
                }
                else
                {
                    newEvents.Add(eve);
                }
            }

            EventOldNewViewModel oldNewViewModel = new EventOldNewViewModel
            {
                NewEvent = newEvents,
                OldEvent = oldEvents
            };

            return View(oldNewViewModel);
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(u => u.Id == userId);
            bool checkregistration = false;
            bool checkpastevent = false;

            Event eEvent = db.Events.SingleOrDefault(e => e.EventId == id);

            var query = (from user in db.Users
                         from Participant in user.Participants
                         where Participant.EventId == id
                         select user).ToList();

            int res = DateTime.Compare(eEvent.EventDate, DateTime.Now);
            checkpastevent = (res < 0) ? true : false;

            checkregistration = query.Contains(currentUser) ? true : false;


            ParticipantViewModel vm = new ParticipantViewModel()
            {
                Event = eEvent,
                Users = query,
                CheckRegistration = checkregistration,
                CheckPastEvent = checkpastevent
            };

            return View(vm);
        }

        public ActionResult Register(int id)
        {
            var currentUser = User.Identity.GetUserId();

            db.Participants.Add(new Participant { Id = currentUser, EventId = id });
            db.SaveChanges();

            Event eEvent = db.Events.SingleOrDefault(eve => eve.EventId == id);
            return View(eEvent);
        }
    }
}