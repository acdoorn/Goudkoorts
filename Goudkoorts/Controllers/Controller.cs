using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Goudkoorts
{
    /*
     *   SD1: Timehandler
     *   SD2: Karrenopschuiven
     *   SD3: KadesControlleren
     *   SD4: KarToevoegen
     * 
     * 
     * 
     * 
     * 
     *   SD: Wissels
     *   SD: Karretje bij Kade - puntentelling
     */
    public class Controller
    {
        private View View;
        private Game Game;
        private Timer timer;
        private int move = 1;
        private int add = 0;

        public Controller()
        {
            View = new View();
          
            Game = new Game(this);
        }

        public void Start()
        {
            Game.TrackContainer = new TrackContainer();

            // Timer aanMaken die altijd loopt
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timerHandler);
            timer.Interval = 100;
            timer.Start();

            while (!Game.IsOver)
            {
                //timer.Start();
            }
            //timer.Stop();

            Console.ReadLine();
        }

        public void Stop()
        {
            Game.IsOver = true;
            timer.Stop();
        }

        public void MakeGUI()
        {
            View.print(Game, move);
            Switch();
        }

        public void Switch()
        {
            int inputkey;
            int index = 0;

            while (!Game.IsOver)
            {
           
                // Vraag om user input
                inputkey = this.getInput();

                switch (inputkey)
                {
                    case 1:
                        index = 9;
                        break;
                    case 2:
                        index = 11;
                        break;
                    case 3:
                        index = 28;
                        break;
                    case 4:
                        index = 30;
                        break;
                    default:
                        index = 12;
                        break;
                }
                TrackSwitch trackSwitch = (TrackSwitch)Game.TrackContainer.SearchIndex(index);
                trackSwitch.Switch();
                MakeGUI();
            }

        }

        public void timerHandler(object source, ElapsedEventArgs e)
        {
            // MOEILIJKHEIDSGRAAD
            Game.changeLevel();

            // move
            if (move == 0)
            {
                Game.MoveCarts();
                Game.CheckDocks();
                move = Game.moveTime;
            }
            else
            {
                move--;
            }

            // add
            if (add == 0)
            {
                Game.AddCart();
                add = Game.addTime;
            }
            else
            {
                add--;
            }

            // GUI BOUWEN
            MakeGUI();
        }

        public int getInput()
        {
            bool wait = true;
            int input = 0;
            while (wait)
            {
                var key = Console.ReadKey(true);
                if ("12345".Contains(key.KeyChar))
                {
                    Int32 number;
                    if (Int32.TryParse(key.KeyChar.ToString(), out number))
                    {
                        input = number;
                        wait = false;
                    }
                }
            }
           
            return input;
        }
    }
}