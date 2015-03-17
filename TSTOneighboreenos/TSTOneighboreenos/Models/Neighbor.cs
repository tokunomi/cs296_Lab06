using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSTOneighboreenos.Models
{
    public class Neighbor
    {
        public int ID { get; set; }
        public string TSTOhandle { get; set; }  // Name player is using on TSTO
        public int Level { get; set; }  // TSTO level
        public string SpringfieldPath { get; set; }  // Path to Springfield screenshot
        public Boolean Active { get; set; }  // Is player active?

        public virtual ICollection<Friend> Friends { get; set; }  // Bridge leading to Players entity/table
    }
}