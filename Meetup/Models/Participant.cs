﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Meetup.Models
{
    public class Participant
    {
        public ApplicationUser User { get; set; }

        public Event Event { get; set; }

        [Key, Column(Order = 1)]
        public string Id { get; set; }

        [Key, Column(Order = 2)]
        public int EventId { get; set; }
    }
}