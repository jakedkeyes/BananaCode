using CodeBanana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BananaCode
{
    internal static class Story
    {
        private static bool _didBananaTree = false;
        private static bool _didTenBananasEvent = false;

        public static bool DidBananaTree
        { 
            get { return _didBananaTree; }
            set { _didBananaTree = value; }
        }
        public static bool DidTenBananasEvent
        {
            get { return _didTenBananasEvent; }
            set { _didTenBananasEvent = value; }
        }

        public static void GameIntro()
        {
            bool answer;
            string input;
            Program.Luffy.Say("Welcome to the Bananaverse.\n");
            UserInterface.Wait(12);
            Program.Luffy.Say("You are the new Banana Coder, yes?\n");

            Program.Luffy.Talking = false;
            answer = UserInterface.BooleanInput();

            UserInterface.Wait(5);
            if (answer)
            {
                Program.Luffy.Say("Good.\n");
                UserInterface.Wait(12);
                Program.Luffy.Say("I've been waiting for you.\n");
                UserInterface.Wait(20);
                Program.Luffy.Say("What is your name?\n");
            }
            else
            {
                Program.Luffy.Say("What the hell are you doing here then? Get out!");
                Environment.Exit(0);
            }

            Program.Luffy.Talking = false;
            Program.Player1 = new Player(UserInterface.NameInput());

            UserInterface.Wait(10);
            Program.Luffy.Say(Program.Player1.Name + ", huh?\n");
            UserInterface.Wait(20);
            Program.Luffy.Say("I haven't heard of you.\n");
            UserInterface.Wait(30);
            Program.Luffy.Say("Oh well.\n");
            UserInterface.Wait(20);
            Program.Luffy.Say("Would you like to know more about the Bananaverse?\n");

            Program.Luffy.Talking = false;
            answer = UserInterface.BooleanInput();

            if (answer)
            {
                BananaverseIntro();
            }
            else
            {
                UserInterface.Wait(5);
                Program.Luffy.Say("Okay. Let's go.\n");
            }

            /*
            Program.Luffy.Say(String.Format("\nThere are currently only {0} bananas left in this world.\n", Bananaverse.Bananas));
            UserInterface.Wait(30);
            Program.Luffy.Say(String.Format("\nThe next banana will be consumed in {0} seconds.", Bananaverse.ConsumptionTimer));
            Bananaverse.RunGame();
            Program.Luffy.Say("\nType banana++; and hit enter to generate one banana.");
            UserInterface.Wait(12);
            Program.Luffy.Say("\nThe Bananaverse depends on it.");
            */

            UserInterface.Wait(40, true);
            Program.Luffy.Say("I will explain more later. For now, all you need to know is that we NEED more bananas!");
            UserInterface.WaitRandom(40);
            Program.Luffy.Say("\nYou were hired as an entry level Programmer at Banana Corp to fulfill this need.");
            UserInterface.WaitRandom(40);
            Program.Luffy.Say($"\nNow, hurry! There are only {Bananaverse.Bananas} bananas left in this world.");

            UserInterface.Wait(30);
            Program.Luffy.Say("\n\nType \"banana += 1;\" and press <enter> to generate 1 banana.\n\n");
            Program.Luffy.Talking = false;
        }
        public static void BananaverseIntro()
        {
            UserInterface.WaitRandom(10);
            Program.Luffy.Say("Okay.");
            UserInterface.WaitRandom(20);
            Program.Luffy.Say("\nThe Bananaverse is everywhere.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nIt is all around us.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nEven now, in this very room.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nYou can see it when you look out your window or when you turn on your television.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nYou can feel it when you go to work... when you go to church...");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nwhen you pay your taxes.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nIt is the world that has been pulled over your...");
            UserInterface.WaitRandom(15);
            Program.Luffy.Say("\nAhem.");
            UserInterface.WaitRandom(20);
            Program.Luffy.Say("\nExcuse me.");
            UserInterface.WaitRandom(40);
            Program.Luffy.Say("\nIt is the world in which we are talking to each other right now.");
            UserInterface.WaitRandom(40);
            Program.Luffy.Say("\nAs time goes on, the Bananaverse consumes more and more bananas.");
            UserInterface.WaitRandom(40);
            Program.Luffy.Say("\nIf the bananas run out");
            UserInterface.Wait(40, true);
            Program.Luffy.Say("Well, no one knows exactly what would happen.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nBut...");
            UserInterface.Wait(30);
            Program.Luffy.Say("\nit seems that the Bananaverse can only continue to exist if it has more bananas to consume.");
            UserInterface.Wait(30);
            UserInterface.WaitForEnter();
        }

        public static void TenBananasEvent()
        {
            UserInterface.Wait(40, true);
            Program.Luffy.Say("\nYou have reached 10 bananas. Well done.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nIf you can reach 25 bananas, I'll have something to teach you.");

        }

        public static void BananaTree()
        {
            UserInterface.Wait(40, true);
            Program.Luffy.Say("Amazing work! We have reached 25 bananas!!");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nWe were so close to... oblivion.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say($"\nThank you, {Program.Player1.Name}. You're doing better than expected.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nBut we're not safe yet. Bananas are still being consumed.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nWe need to create code that can generate bananas automatically.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nYou can add a constant banana gain rate by creating a BananaTree object.");
            UserInterface.WaitRandom(30);
            Program.Luffy.Say("\nTo create a new Banana Tree, type \"Bananaverse.AddBananaTree();\"");
        }
    }
}
