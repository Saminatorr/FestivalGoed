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
    class Genre
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

        public static ObservableCollection<Genre> Genres()
        {
            //ObservableCollection<Band> _bands = new ObservableCollection<Band>();
            //_bands.Add(new Band() {Name="Giraffic", Id="1", Description="Lekkere drummer", Twitter="NA", Facebook="facebooklalala"});
            //_bands.Add(new Band() { Name = "Gravix", Id = "2", Description = "Andere Band", Twitter = "NA", Facebook = "facebooktralala" });
            //return _bands;
            ObservableCollection<Genre> _genres = new ObservableCollection<Genre>();
            string sql = "SELECT * FROM Genres";
            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                _genres.Add(VerwerkRij(reader));
            }

            return _genres;
        }

        public static Genre VerwerkRij(IDataRecord rij)
        {
            Genre newGenre = new Genre();

            newGenre.Id = rij["ID"].ToString();
            newGenre.Name = rij["Name"].ToString();
            return newGenre;
        }

        public static void SaveGenre(Genre SelectedGenre)
        {
            string sql = "INSERT INTO Genres(ID, Name) VALUES (@ID, @Name)";
            DbParameter par1 = Database.AddParameter("@ID", "test");
            DbParameter par2 = Database.AddParameter("@Name", SelectedGenre.Name);
            Database.ModifyData(sql, par1, par2);
        }

        public static void AddGenre(Genre g)
        {
            Console.WriteLine(g.Name + " was added");
        }

        public static void Remove(Genre s)
        {
            Console.WriteLine(s.Name + " was removed");
        }
    }
}
