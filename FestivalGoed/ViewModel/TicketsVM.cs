using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalGoed.ViewModel
{
    class TicketsVM : ObservableObject, IPage
    {
        public string Name 
        {
            get 
            {
                return "Tickets";
            }
        }
    }
}
