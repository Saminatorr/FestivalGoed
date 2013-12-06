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
    class ContactPersonenVM : ObservableObject, IPage
    {
        public string Name 
        {
            get 
            {
                return "ContactPersonen";
            }
        }

        private Contactperson _selectedContact;
        public Contactperson SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value; OnPropertyChanged("SelectedContact"); }
        }

        private ObservableCollection<Contactperson> _contacten;
        public ObservableCollection<Contactperson> Contacten
        {
            get{ return _contacten; }
            set{ _contacten = value; OnPropertyChanged("Contacten"); }
        }

        private ObservableCollection<ContactpersonType> _contactTypes;
        public ObservableCollection<ContactpersonType> ContactTypes
        {
            get { return _contactTypes; }
            set { _contactTypes = value; OnPropertyChanged("ContactTypes"); }
        }
        

        public ContactPersonenVM()
        {
            Contacten = Contactperson.Contacts();
            SelectedContact = new Contactperson(); //how many times did i say this
            //Person = new Contactperson();
            //ContactTypes = ContactpersonType.
        }

        //private Contactperson _person;

        //public Contactperson Person
        //{
        //    get { return _person; }
        //    set { _person = value; OnPropertyChanged("Person"); }
        //}

        public ICommand AddContactCommand
        {
            get { return new RelayCommand(AddContact); }
        }
        //knop aanmaken waardoor de tekstvelden leeg komen een ook de Selectedperson null wordt
        //en bij je addcontact kan je dan weer SelectedContact = new Contactperson();
        //dan zou hij niet meer moeten crashen nadat je iets delete
        //OK? uhu i guessssss kut :p hf
        public void AddContact()
        {
            //Contactperson newContact = new Contactperson();
            ////string test = txtNaamContact.Text;
            ////newContact.Name = 
            ////newContact.Name = txt
            //newContact

            //Contacten.Add(newContact);
            //Contactperson.AddContact(newContact);
            //SelectedContact = newContact;

            //Console.WriteLine(Person.Name);

            //Contactperson newContact = new Contactperson();
            //newContact.Name = Person.Name;
            //newContact.Company = Person.Company;
            //newContact.City = Person.City;
            //newContact.Email = Person.Email;
            //newContact.Phone = Person.Phone;
            //newContact.Opmerkingen = Person.Opmerkingen;
            //Contacten.Add(newContact);
            //SelectedContact = newContact;

            Contactperson contact = new Contactperson()
            {
                Name = SelectedContact.Name,
                Company = SelectedContact.Company,
                City = SelectedContact.City,
                Email = SelectedContact.Email,
                Phone = SelectedContact.Phone,
                Opmerkingen = SelectedContact.Opmerkingen

            };
            Contacten.Add(contact);
            Contactperson.SaveContactperson(SelectedContact);
            SelectedContact = new Contactperson();
        }

        public ICommand ClearFields
        {
            get { return new RelayCommand(ClearAllFields); }
        }

        public void ClearAllFields() 
        {
            SelectedContact = new Contactperson();
        }

        public ICommand DeleteShopCommand
        {
            get { return new RelayCommand(DeleteShop); }
        }

        public void DeleteShop()
        {
            //Contactperson.Remove(SelectedContact);
            Contacten.Remove(SelectedContact);
            SelectedContact = new Contactperson();
        }

    }
}
