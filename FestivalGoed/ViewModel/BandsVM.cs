using FestivalGoed.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FestivalGoed.ViewModel
{
    class BandsVM : ObservableObject, IPage
    {
        public string Name
        {
            get
            {
                return "Bands";
            }
        }

        private Band _selectedBand;
        public Band SelectedBand
        {
            get { return _selectedBand; }
            set { _selectedBand = value; OnPropertyChanged("SelectedBand"); }
        }

        private ObservableCollection<Band> _bands;
        public ObservableCollection<Band> Bands
        {
            get { return _bands; }
            set { _bands = value; OnPropertyChanged("Bands"); }
        }

        private ObservableCollection<Band> _genres;
        public ObservableCollection<Band> Genres
        {
            get { return _genres; }
            set { _genres = value; OnPropertyChanged("Genres"); }
        }

        public BandsVM()
        {
            Bands = Band.Bands();
            SelectedBand = new Band();
        }

        public ICommand AddBandCommand
        {
            get { return new RelayCommand(AddBand); }
        }

        public void AddBand()
        {

            Band band = new Band()
            {
                Name = SelectedBand.Name,
                Description = SelectedBand.Description,

            };
            Bands.Add(band);
            Band.SaveBand(SelectedBand);
            SelectedBand = new Band();
        }

        public ICommand ClearFields
        {
            get { return new RelayCommand(ClearAllFields); }
        }

        public void ClearAllFields()
        {
            SelectedBand = new Band();
        }

        public ICommand DeleteBandCommand
        {
            get { return new RelayCommand(DeleteBand); }
        }

        public void DeleteBand()
        {
            //Contactperson.Remove(SelectedContact);
            Bands.Remove(SelectedBand);
            SelectedBand = new Band();
        }
    }
}
