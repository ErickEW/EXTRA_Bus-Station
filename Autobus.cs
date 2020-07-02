using System;

namespace Extra_Bus_Station
{
    class Autobus
    {
        string name { get; set;}

        char route {get; set;}

        public Autobus (string name, char route)
        {
            this.name = name;
            this.route = route;
        }

        public string Name()
        {
            return name;
        }

        public char Route()
        {
            return route;
        }
        
    }
}
