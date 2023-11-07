using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaCode
{
    internal class Player : Character
    {
        public Player(string name) : base(name) { }

        public void LearnName(NPC npc)
        {
            npc.PlayerKnowsName = true;
        }

        public void StartTalking()
        {
            Program.Luffy.Talking = false;
            Console.WriteLine("{0}:", _name);
        }
    }
}
