using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalGoed.Model
{
    public class ContactpersonType
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

        public List<ContactpersonType> ContactTypes 
        {
            get 
            {
                List<ContactpersonType> _types = new List<ContactpersonType>();
                _types.Add(new ContactpersonType() { Name = "Geluid", Id = "een" });
                _types.Add(new ContactpersonType() { Name = "Licht", Id = "twee" });
                return _types;
            }
        }


        public ContactpersonType GetTypes(string code) 
        {
            foreach (ContactpersonType ct in ContactTypes) 
            {
                if (ct.Id == code)
                    return ct;
            }
            return null;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
