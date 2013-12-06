using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FestivalGoed.Model
{
    public class Contactperson
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

        private string _company;

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        private ContactpersonType _jobRole;

        public ContactpersonType JobRole
        {
            get { return _jobRole; }
            set { _jobRole = value; }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _cellphone;

        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }

        private string _opmerkingen;

        public string Opmerkingen
        {
            get { return _opmerkingen; }
            set { _opmerkingen = value; }
        }
        

        public static ObservableCollection<Contactperson> Contacts()
        {

            ObservableCollection<Contactperson> _contacts = new ObservableCollection<Contactperson>();
            string sql = "SELECT * FROM Contactpersonen";
            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                _contacts.Add(VerwerkRij(reader));
            }

            return _contacts;
        }

        public static Contactperson VerwerkRij(IDataRecord rij)
        {
            Contactperson nieuwContact = new Contactperson();

            nieuwContact.Id = rij["ID"].ToString();
            nieuwContact.Name = rij["Name"].ToString();
            nieuwContact.Company = rij["Company"].ToString();

            return nieuwContact;
        }

        public static void SaveContactperson(Contactperson SelectedContact) 
        {
            string sql = "INSERT INTO Contactpersonen(ID, Name, Company) VALUES (@ID, @Name, @Company)";
            DbParameter par1 = Database.AddParameter("@ID", "test");
            DbParameter par2 = Database.AddParameter("@Name", SelectedContact.Name);
            DbParameter par3 = Database.AddParameter("@Company", SelectedContact.Company);
            Database.ModifyData(sql, par1, par2, par3);
        }


        public static void AddContact(Contactperson cp)
        {
            Console.WriteLine(cp.Name + " was added");
        }

        public static void Remove(Contactperson s)
        {
            Console.WriteLine(s.Name + " was removed");
        }

    }
}
