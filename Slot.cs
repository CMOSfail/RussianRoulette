using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette02
{
    internal class Slot
    {
        public bool IsLoaded { get; set; }
        public bool IsShot { get; set; }

        public Slot(bool isLoaded, bool isShot)
        {
            IsLoaded = isLoaded;
            IsShot = isShot;
        }
    }
}
