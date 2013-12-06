using FestivalGoed.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FestivalGoed.ViewModel
{
    class BeherenVM : ObservableObject, IPage
    {
        public string Name 
        {
            get
            {
                return "Beheren";
            }
        }

        private Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get { return _selectedGenre; }
            set { _selectedGenre = value; OnPropertyChanged("SelectedGenre"); }
        }

        private ObservableCollection<Genre> _genres;
        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; OnPropertyChanged("Genres"); }
        }

        public BeherenVM()
        {
            Genres = Genre.Genres();
            SelectedGenre = new Genre();
        }

        public ICommand AddGenreCommand
        {
            get { return new RelayCommand(AddGenre); }
        }

        public void AddGenre()
        {

            Genre band = new Genre()
            {
                Name = SelectedGenre.Name,

            };
            Genres.Add(band);
            Genre.SaveGenre(SelectedGenre);
            SelectedGenre = new Genre();
        }

        public ICommand DeleteGenreCommand
        {
            get { return new RelayCommand(DeleteGenre); }
        }

        public void DeleteGenre()
        {
            //Contactperson.Remove(SelectedContact);
            Genres.Remove(SelectedGenre);
            SelectedGenre = new Genre();
        }
    }
}
