using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaCode
{
    public abstract class Character
    {
        protected string _name;
        protected bool _talking = false;

        public Character()
        {

        }
        public Character(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Talking
        {
            get { return _talking; }
            set { _talking = value; }
        }
    }
}
