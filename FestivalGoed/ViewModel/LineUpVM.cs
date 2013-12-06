using FestivalGoed.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalGoed.ViewModel
{
    class LineUpVM : ObservableObject, IPage
    {
        public string Name 
        {
            get 
            {
                return "LineUp";
            }
        }

        private Band _selectedBand;
        public Band SelectedBand
        {
            get { return _selectedBand; }
            set { _selectedBand = value; OnPropertyChanged("SelectedBand"); }
        }

        private ObservableCollection<Band> _bands;
        public ObservableCollection<Band> Banden
        {
            get{ return _bands; }
            set { _bands = value; OnPropertyChanged("Banden"); }
        }

        public LineUpVM()
        {
            Banden = Band.Bands();
            
        }


    }
}
