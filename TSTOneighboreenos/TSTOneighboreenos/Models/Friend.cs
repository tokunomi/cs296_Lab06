using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSTOneighboreenos.Models
{
    public class Friend
    {
        public int ID { get; set; }

        // Foreign Keys
        public int PlayerID { get; set; }
        public int NeighborID { get; set; }

        // Navigation properties
        public virtual Player Player { get; set; }
        public virtual Neighbor Neighbor { get; set; }

    }
}
