using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalGoed.Model
{
    class Band
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _twitter;

        public string Twitter
        {
            get { return _twitter; }
            set { _twitter = value; }
        }

        private string _facebook;

        public string Facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }

        private ObservableCollection<Genre> _genres;

        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; }
        }


        public static ObservableCollection<Band> Bands() 
        {
            //ObservableCollection<Band> _bands = new ObservableCollection<Band>();
            //_bands.Add(new Band() {Name="Giraffic", Id="1", Description="Lekkere drummer", Twitter="NA", Facebook="facebooklalala"});
            //_bands.Add(new Band() { Name = "Gravix", Id = "2", Description = "Andere Band", Twitter = "NA", Facebook = "facebooktralala" });
            //return _bands;
            ObservableCollection<Band> _bands = new ObservableCollection<Band>();
            string sql = "SELECT * FROM Banden";
            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                _bands.Add(VerwerkRij(reader));
            }

            return _bands;
        }

        public static Band VerwerkRij(IDataRecord rij)
        {
            Band newBand = new Band();

            newBand.Id = rij["ID"].ToString();
            newBand.Name = rij["Name"].ToString();
            newBand.Description = rij["Description"].ToString();


            return newBand;
        }

        public static void SaveBand(Band SelectedBand) 
        {
            string sql = "INSERT INTO Banden(ID, Name, Description) VALUES (@ID, @Name, @Description)";
            DbParameter par1 = Database.AddParameter("@ID", "test");
            DbParameter par2 = Database.AddParameter("@Name", SelectedBand.Name);
            DbParameter par3 = Database.AddParameter("@Description", SelectedBand.Description);
            Database.ModifyData(sql, par1, par2, par3);
        }

        

        public static void AddContact(Band b)
        {
            Console.WriteLine(b.Name + " was added");
        }

        public static void Remove(Band s)
        {
            Console.WriteLine(s.Name + " was removed");
        }


        //public static ObservableCollection<Contactperson> Contacts()
        //{
        //    ContactpersonType ct = new ContactpersonType();
        //    ObservableCollection<Contactperson> _contacts = new ObservableCollection<Contactperson>();
        //    _contacts.Add(new Contactperson() { Name = "Sam", Company = "Boss", City = "Brugge", Email = "sexy", Phone = "cool", JobRole = ct.GetTypes("een"), Opmerkingen = "super heet" });
        //    _contacts.Add(new Contactperson() { Name = "Tine", Company = "Noob", City = "Brugge", Email = "poes", Phone = "warm", JobRole = ct.GetTypes("twee"), Opmerkingen = "lekker nat" });
        //    return _contacts;
        //}
    }
}
