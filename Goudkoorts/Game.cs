using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Game
    {
        private Controller controller;
        public List<Cart> Cartren;

        public bool IsOver { get; set; }
        public int Points { get; set; }
        public int Level { get; set; }
        public int addInTurn { get; set; }
        public TrackContainer TrackContainer { get; set; }
        public int moveTime { get; set; }
        public int addTime { get; set; }

        public Game(Controller controller)
        {
            this.controller = controller;
            Cartren = new List<Cart>();
            IsOver = false;
            Level = 1;
            addInTurn = 1;
            moveTime = 3;
            addTime = 5;
        }

        public void CheckDocks()
        {
            // Controleer of een van de Docks geen Ship heeft
            Track Track1 = TrackContainer.SearchIndex(19);
            Dock Dock1 = (Dock)Track1;

            Track Track2 = TrackContainer.SearchIndex(44);
            Dock Dock2 = (Dock)Track2;

            DockControlleren(Dock1);
            DockControlleren(Dock2);
        }

        public void DockControlleren(Dock Dock)
        {
            if (!Dock.hasShip())
            {
                if (Dock.RoundsWithoutShip > 2)
                {
                    Dock.Ship = new Ship();
                    Dock.RoundsWithoutShip = 0;
                }
                else
                {
                    Dock.RoundsWithoutShip++;
                }
            }
        }

        public void AddCart()
        {
            if (addInTurn == 0)
            {
                int[] numbers = new int[3] { 0, 20, 31 };
                Random rd = new Random();
                int randomIndex = rd.Next(0, 3);
                int randomNumber = numbers[randomIndex];

                Track track = TrackContainer.SearchIndex(randomNumber);
                // Index zetten, zodat we adhv lijst Cartren weten waar Cart staat
                Cart Cart = new Cart { Index = randomNumber };
                Cartren.Add(Cart);
                track.Cart = Cart;
                addInTurn = 1;
            }
            else
            {
                addInTurn--;
            }
        }

        public void MoveCarts()
        {
            TrackSwitch w = null;
            Dock k = null;
            List<Cart> delete = new List<Cart>();
            Track next = null;

            foreach (Cart Cart in Cartren)
            {

                // TrackContainervak zoeken
                Track track = TrackContainer.SearchIndex(Cart.Index);

                // Kijken of VOLGEND TrackContainervaak een wissel is
                if (track.Next != null && track.Next.GetType().Name == "TrackSwitch")
                {
                    w = (TrackSwitch)track.Next;

                    if (w.TrackType == TrackType.TwoInOneOut)
                    {
                        // Wanneer stand van wissel op Boven staat
                        if (w.Position == Position.Up)
                        {
                            // Wanneer inkomend TrackContainervak gelijk is aan Boven
                            if (track == w.Up)
                            {
                                next = w;
                            }
                        }
                        else if (w.Position == Position.Down)
                        {
                            if (track == w.Down)
                            {
                                next = w;
                            }
                        }
                    }
                    else
                    {
                        next = track.Next;
                    }
                }
                // Kijken of HUIDIG TrackContainervak wissel is
                else if (track.GetType().Name == "TrackSwitch")
                {
                    w = (TrackSwitch)track;

                    if (w.TrackType == TrackType.OneInTwoOut)
                    {
                        if (w.Position == Position.Up)
                        {
                            next = w.Up;
                        }
                        else
                        {
                            next = w.Down;
                        }
                    }
                    else
                    {
                        next = track.Next;
                    }
                }
                // Als volgende normaal TrackContainervak is
                else if (track.GetType().Name == "Track" || track.GetType().Name == "Start")
                {
                    next = track.Next;
                }
                else if (track.GetType().Name == "Dock")
                {
                    k = (Dock)track;

                    if (k.hasShip())
                    {
                        Points += k.fillShip();
                    }

                    track.Cart = null;
                    delete.Add(Cart);
                }
                //TODO
                try
                {
                    moveCart(track, next);
                }
                catch (Exception_CantMoveCart e)
                {
                    controller.Stop();
                    Console.WriteLine(e.ToString());
                    Console.ReadLine();
                    //throw new Exception_KanCartNietVerplaatsen();
                }

                next = null;

            }

            // Remove Cartren from Cartren outside foreach loop
            foreach (Cart Cart in delete)
            {
                Cartren.Remove(Cart);
            }
        }

        public void moveCart(Track current, Track next)
        {
            if (next != null)
            {
                if (next.Cart == null)
                {
                    // Zet Cart op volgende
                    next.Cart = current.Cart;
                    current.Cart.Index = next.Index;

                    // Reset huidig
                    current.Cart = null;
                }
                else
                {
                    throw new Exception_KanCartNietVerplaatsen();
                }
            }
        }

        public void MoeilijkheidsgraadToepassen()
        {
            if (Points >= 30 && Points <= 59)
            {
                moveTime = 3;
                Level = 2;
            }
            else if (Points >= 60 && Points <= 89)
            {
                moveTime = 2;
                addTime = 2;
                Level = 3;
            }
            else if (Points >= 90)
            {
                moveTime = 1;
                addTime = 1;
                Level = 4;
            }
        }
    }
}
