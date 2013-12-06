using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalGoed.Model
{
    class Ticket
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _ticketholder;

        public string Ticketholder
        {
            get { return _ticketholder; }
            set { _ticketholder = value; }
        }

        private string _ticketholderEmail;

        public string TicketholderEmail
        {
            get { return _ticketholderEmail; }
            set { _ticketholderEmail = value; }
        }

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
