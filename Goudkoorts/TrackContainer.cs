using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class TrackContainer
    {
        
	public int TrackAmount { get; set; }

    public Track StartA;
    public Track StartB;
    public Track StartC;

    public TrackContainer()
    {
        TrackAmount = 44;
        this.Add();
        
    }

    public Track SearchIndex(int key)
    {
        Track Track = SearchRouteA(key);
        if (Track == null)
        {
            Track = SearchRouteB(key);
            if (Track == null)
            {
                Track = SearchRouteC(key);
            }
        }
        return Track;
    }

    private Track SearchRouteA(int key)
    {
        Track current = StartA;
        TrackSwitch w = null;
        while (current.Index != key)
        {
            if (current.GetType().Name == "TrackSwitch")
            {
                w = (TrackSwitch)current;
                if (w.TrackType == TrackType.TwoInOneOut)
                {
                    current = w.Next;
                }
                else
                {
                    current = w.Up;
                }
            }
            else
            {
                if (current.Next == null)
                {
                    return null;
                }
                else
                {
                    current = current.Next;
                }
            }
        }
        return current;
    }

    private Track SearchRouteB(int key)
    {
        Track current = StartB;
        TrackSwitch w = null;
        while (current.Index != key)
        {
            if (current.GetType().Name == "TrackSwitch")
            {
                w = (TrackSwitch)current;
                if (w.TrackType == TrackType.TwoInOneOut)
                {
                    current = w.Next;
                }
                else
                {
                    if (w.Index == 11)
                    {
                        current = w.Down;
                    }
                    if (w.Index == 30)
                    {
                        current = w.Up;
                    }
                }
            }
            else
            {
                if (current.Next == null)
                {
                    return null;
                }
                else
                {
                    current = current.Next;
                }
            }
        }
        return current;
    }

    private Track SearchRouteC(int key)
    {
        Track current = StartC;
        TrackSwitch w = null;
        while (current.Index != key)
        {
            if (current.GetType().Name == "TrackSwitch")
            {
                w = (TrackSwitch)current;
                if (w.TrackType == TrackType.TwoInOneOut)
                {
                    current = w.Next;
                }
                else
                {
                    current = w.Down;
                }
            }
            else
            {
                if (current.Next == null)
                {
                    return null;
                }
                else
                {
                    current = current.Next;
                }
            }
        }
        return current;
    }

    private void Add()
	{
        StartA = new Start{Index = 0, Display = "A"};
        StartB = new Start{Index = 20, Display = "B"};
        StartC = new Start{Index = 31, Display = "C"};

        TrackSwitch TrackSwitchA = new TrackSwitch{Index = 9, Display = "\\"};
        TrackSwitch TrackSwitchB = new TrackSwitch{Index = 11, Display = "/"};
        TrackSwitch TrackSwitchC = new TrackSwitch{Index = 28, Display = "\\"};
        TrackSwitch TrackSwitchD = new TrackSwitch{Index = 30, Display = "/"};
        TrackSwitch TrackSwitchE = new TrackSwitch{Index = 12, Display = "\\"};

        Dock DockA = new Dock { Index = 19, Display = "K", Ship = new Ship() };
        Dock DockB = new Dock { Index = 44, Display = "K", Ship = new Ship() };

        Track Track0 = new Track{Index = 1};
        Track Track1 = new Track{Index = 2};
        Track Track2 = new Track{Index = 3};
        Track Track4 = new Track{Index = 21};
        Track Track5 = new Track{Index = 22};
        Track Track6 = new Track{Index = 23};
        Track Track7 = new Track{Index = 10};
        Track Track8 = new Track{Index = 4};
        Track Track9 = new Track{Index = 5};
        Track Track10 = new Track{Index = 6};
        Track Track11 = new Track{Index = 7};
        Track Track12 = new Track{Index = 8};
        Track Track13 = new Track{Index = 24};
        Track Track14 = new Track{Index = 25};
        Track Track15 = new Track{Index = 29};
        Track Track16 = new Track{Index = 26};
        Track Track17 = new Track{Index = 27};
        Track Track18 = new Track{Index = 38};
        Track Track19 = new Track{Index = 39};
        Track Track20 = new Track{Index = 40};
        Track Track21 = new Track{Index = 41};
        Track Track22 = new Track{Index = 42};
        Track Track23 = new Track{Index = 43};
        Track Track25 = new Track{Index = 13};
        Track Track26 = new Track{Index = 14};
        Track Track27 = new Track{Index = 15};
        Track Track28 = new Track{Index = 16};
        Track Track29 = new Track{Index = 17};
        Track Track30 = new Track{Index = 18};
        Track Track31 = new Track{Index = 32};
        Track Track32 = new Track{Index = 33};
        Track Track33 = new Track{Index = 34};
        Track Track34 = new Track{Index = 35};
        Track Track35 = new Track{Index = 36};
        Track Track36 = new Track{Index = 37};

        // TrackSwitch A
        TrackSwitchA.TrackType = TrackType.TwoInOneOut;
        TrackSwitchA.Up = Track2;
        TrackSwitchA.Down = Track6;

        // TrackSwitch B
        TrackSwitchB.TrackType = TrackType.OneInTwoOut;
        TrackSwitchB.Up = Track8;
        TrackSwitchB.Down = Track13;

        // TrackSwitch C
        TrackSwitchC.TrackType = TrackType.TwoInOneOut;
        TrackSwitchC.Up = Track14;
        TrackSwitchC.Down = Track36;

        // TrackSwitch D
        TrackSwitchD.TrackType = TrackType.OneInTwoOut;
        TrackSwitchD.Up = Track16;
        TrackSwitchD.Down = Track18;

        // TrackSwitch E
        TrackSwitchE.TrackType = TrackType.TwoInOneOut;
        TrackSwitchE.Up = Track12;
        TrackSwitchE.Down = Track17;

        // Route A
        StartA.Next = Track0;
        Track0.Next = Track1;
        Track1.Next = Track2;
        Track2.Next = TrackSwitchA;

        // Route B
        StartB.Next = Track4;
        Track4.Next = Track5;
        Track5.Next = Track6;
        Track6.Next = TrackSwitchA;

        // Route C
        TrackSwitchA.Next = Track7;
        Track7.Next = TrackSwitchB;

        // Route D
        Track8.Next = Track9;
        Track9.Next = Track10;
        Track10.Next = Track11;
        Track11.Next = Track12;
        Track12.Next = TrackSwitchE;
        
        // Route E
        Track13.Next = Track14;
        Track14.Next = TrackSwitchC;

        // Route F
        TrackSwitchC.Next = Track15;
        Track15.Next = TrackSwitchD;

        // Route G
        Track16.Next = Track17;
        Track17.Next = TrackSwitchE;

        // Route H
        Track18.Next = Track19;
        Track19.Next = Track20;
        Track20.Next = Track21;
        Track21.Next = Track22;
        Track22.Next = Track23;
        Track23.Next = DockB;

        // Route I
        TrackSwitchE.Next = Track25;
        Track25.Next = Track26;
        Track26.Next = Track27;
        Track27.Next = Track28;
        Track28.Next = Track29;
        Track29.Next = Track30;
        Track30.Next = DockA;

        // Route J
        StartC.Next = Track31;
        Track31.Next = Track32;
        Track32.Next = Track33;
        Track33.Next = Track34;
        Track34.Next = Track35;
        Track35.Next = Track36;
        Track36.Next = TrackSwitchC;
	}
    }
}
