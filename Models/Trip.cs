using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanesTrainsandAutomobiles.Models
{
    public class Trip : Virtual<int>
    {
        public string Name { get; set; }
    }
}