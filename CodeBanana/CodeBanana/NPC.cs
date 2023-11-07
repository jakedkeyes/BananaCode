using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BananaCode
{
    internal class NPC : Character
    {
        private bool _playerKnowsName = false;
        public NPC(string name) : base(name) { }

        public void Say(string message)
        {
            if (!_talking)
            {
                _talking = true;
                Console.Write("{0}:\n", _displayName);
            }
            Console.Write("{0}", message);
        }

        public bool PlayerKnowsName
        {
            get
            {
                return _playerKnowsName;
            }
            set
            {
                _playerKnowsName = value;
            }
        }

        private string _displayName
        {
            get
            {
                if (_playerKnowsName)
                {
                    return _name;
                }
                else
                {
                    return "Unknown";
                }
            }
        }
    }
}
