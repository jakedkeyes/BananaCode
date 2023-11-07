using CodeBanana;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BananaCode
{
    class Program
    {
        private static bool _skipIntro = false;
        private static bool _gameRunning = false;
        private Stopwatch _timer = new Stopwatch();

        private static bool _answer = false;
        private static string _codeInput = "";
        private static bool _takeCodeInput = false;

        public static bool TakeCodeInput
        {
            get { return _takeCodeInput; }
            set { _takeCodeInput = value; }
        }
        public static bool GameRunning { get { return _gameRunning; } }

        public static NPC Luffy = new NPC("Monkey D Luffy");
        public static Player Player1;
        static async Task Main(string[] args)
        {
            if (!_skipIntro)
            {
                Story.GameIntro();
            }
            else
            {
                Player1 = new Player("Jake");
            }
            StartGame();
        }

        public static async Task Update()
        {
            if (_takeCodeInput)
            {
                _codeInput = UserInterface.CodeInput().ToString();
            }

            if(!Bananaverse.Consuming) await Bananaverse.ConsumeBanana();

            if (!Bananaverse.HarvestingBananaTrees)
            {
                await Bananaverse.HarvestBananaTrees();
            }

            if(!Story.DidBananaTree)
            {
                if (Bananaverse.Bananas >= 25)
                {
                    PauseGame();
                    Story.BananaTree();
                    Story.DidBananaTree = true;
                    UserInterface.WaitForEnter();
                    StartGame();
                }
            }

            /*
            if (!Story.DidTenBananasEvent)
            {
                if(Bananaverse.Bananas >= 10)
                {
                    PauseGame();
                    Story.TenBananasEvent();
                    Story.DidTenBananasEvent = true;
                    StartGame();
                }
            }
            */

        }

        public static void CallUpdate()
        {
            while (_gameRunning)
            {
                Update();
            }
        }

        public static void StartGame()
        {
            _gameRunning = true;
            _takeCodeInput = true;
            CallUpdate();
        }
        public static void PauseGame()
        {
            _gameRunning = false;
            _takeCodeInput = false;
        }
    }
}