using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TSTOneighboreenos.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string TSTOhandle { get; set; }  // Name player is using on TSTO
        public int Level { get; set; }  // TSTO level
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string NameFirst { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string NameLast { get; set; }
        [Display(Name = "Middle Initial")]
        [StringLength(1)]
        public string MidInit { get; set; }  // Middle initial (optional)
        // public char MidInit { get; set; }  // original datatype
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        public string SpringfieldPath { get; set; }  // Path to Springfield screenshot
        public Boolean Active { get; set; }  // Is player active?
        public Boolean AddMe { get; set; }  // Looking for new neighbors?

        public virtual ICollection<Friend> Friends { get; set; }  // Bridge leading to Neighbors entity/table
    }
}