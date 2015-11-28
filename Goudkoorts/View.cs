using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{

    public class View
    {
	   
            public void print(Game g, int countdown)
            {
                Console.Clear();
                Console.WriteLine(" **************   **************   **************   **************");
                Console.WriteLine(" * Goldfever  *   * Points: " + g.Points.ToString().PadLeft(3) + " *   * Time: " + countdown + "     *   * Level:  " + g.Level + "   *");
                Console.WriteLine(" **************   **************   **************  **************");
                Console.WriteLine("─────────────────────────────────");
                printTrack(g.TrackContainer);
                Console.WriteLine("─────────────────────────────────");
                Console.WriteLine(" Press a key between 1 and 5 to activate a switch!");
                
            }
        
            public void printTrack(TrackContainer t)
            {
                Console.Write(" ");
                for (int i = 0; i <= t.TrackAmount; i++)
                {
                    Track tr = t.SearchIndex(i);

                    switch (i)
                    {
                        case 4:
                            Console.Write("    ");
                            break;
                        case 9:
                            Console.WriteLine("");
                            Console.Write("     ");
                            break;
                        case 12: 
                            Console.Write("       ");
                            break;
                        case 20:
                            Console.WriteLine("");
                            Console.Write(" ");
                            break;
                        case 24:
                            Console.Write("   ");
                            break;
                        case 26:
                            Console.Write("   ");
                            break;
                        case 28:
                            Console.WriteLine("");
                            Console.Write("          ");
                            break;
                        case 31:
                            Console.WriteLine("");
                            Console.Write(" ");
                            break;
                        case 32:
                            Console.Write(" ");
                            break;
                        case 38:
                            Console.Write("     ");
                            break;
                        default:
                            break;
                    }

                    if (tr.GetType().Name == "Dock")
                    {
                        Dock dock = (Dock)tr;
                        if (Dock.hasShip())
                        {
                            Console.Write(tr.Display + " (schip  " + dock.Ship.Content + "/" + dock.Ship.MaxContent + ")");
                        }
                        else
                        {
                            Console.Write(tr.Display);
                        }
                    }
                    else { 
                        Console.Write(tr.Display);
                    }
                }
                Console.WriteLine("");
            }
    }
}