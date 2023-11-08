using BananaCode;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;

namespace CodeBanana
{
    public static class Bananaverse
    {
        private static double _bananas = 5;
        private static int _consumptionTimer = 15;
        private static int _remainingTime = _consumptionTimer;
        private static bool _consuming = false;
        private static bool _harvestingBananaTrees = false;
        private static List<BananaTree> BananaTrees = new List<BananaTree>();

        public static bool Consuming
        {
            get { return _consuming; }
            set { _consuming = value; }
        }

        public static bool HarvestingBananaTrees
        {
            get { return _harvestingBananaTrees; }
            set { _harvestingBananaTrees = value; }
        }

        public static double Bananas
        {
            get { return _bananas; }
            set { _bananas = value; }
        }
        public static int ConsumptionTimer
        {
            get { return _consumptionTimer; }
            set { _consumptionTimer = value; }
        }
        public static int RemainingTime
        {
            get { return _remainingTime; }
            set { _remainingTime = value; }
        }

        public static async Task<bool> Countdown()
        {
            await Task.Delay(15000);
            return true;
        }

        public static async Task<bool> HarvestBananaTreesCountdown()
        {
            await Task.Delay(1000);
            return true;
        }

        
        public static async Task ConsumeBanana()
        {
            _consuming = true;
            await Countdown();
            while (!Program.GameRunning)
            {

            }
            Bananas -= 1;
            _consuming = false;
            Console.WriteLine($"\nA banana has been consumed. There are {Bananas.ToString("#")} bananas remaining.\n");
        }


        public static void AddBananaTree()
        {
            if(_bananas >= 25)
            {
                BananaTree newTree = new BananaTree();
                BananaTrees.Add(newTree);
                _bananas -= 25;
                Console.WriteLine($"You have generated a new Banana Tree. Your new Banana Rate is {GetBananaRate().ToString("#.##")} per second.");
            }
            else
            {
                Console.WriteLine("\nYou don't have enough bananas for a Banana Tree.");
            }
        }

        public static async Task HarvestBananaTrees()
        {
            _harvestingBananaTrees = true;
            await HarvestBananaTreesCountdown();
            while(!Program.GameRunning)
            {

            }
            Bananas += GetBananaRate();
            _harvestingBananaTrees = false;
        }

        public static double GetBananaRate()
        {
            double rate = 0;
            for(int i = 0; i < BananaTrees.Count; i++)
            {
                rate += BananaTrees.ElementAt(i).BananasPerSecond;
            }
            return rate;
        }

        public class BananaTree
        {
            private double _bananasPerSecond;
            public BananaTree()
            {
                _bananasPerSecond = 0.01;
            }

            public double BananasPerSecond
            {
                get { return _bananasPerSecond; }
                set { _bananasPerSecond = value;}
            }
        }
    }
}
