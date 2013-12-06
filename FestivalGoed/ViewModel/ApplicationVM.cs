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
    //dit is het hart van de applicatie
    class ApplicationVM : ObservableObject
    {

        public ApplicationVM()
        {
            _pages = new ObservableCollection<IPage>();

            //hieronder vul je deze collectie op met alle viewmodel-klassen (die horen bij een usercontrol)
            _pages.Add(new MainPageVM());
            _pages.Add(new ContactPersonenVM());
            _pages.Add(new BandsVM());
            _pages.Add(new LineUpVM());
            _pages.Add(new TicketsVM());
            _pages.Add(new BeherenVM());

            //bij opstarten direct de eerste user control tonen
            CurrentPage = Pages[0];

        }

        //dit attribuut (en bijhoorden property) houden de zichtbare usercontrol bij
        //pas op, hieronder wordt in principe de ViewModel-klasse (horende bij deze usercontrol bij gehouden)
        //de omzetting van viewModel-klasse naar de juist usercontrol zit in MainWindow.xaml
        private IPage _currentPage;
        public IPage CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private ObservableCollection<IPage> _pages;
        public ObservableCollection<IPage> Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;

            }
        }

        //deze methode wordt gebruikt door de buttons die op MainWindow zitten
        //deze buttons doen de getoonde usercontrol veranderen
        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }
        private void ChangePage(IPage page)
        {
            CurrentPage = page;
        }

    }
}
