using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSTOneighboreenos.Models
{
    public class Gallery
    {
        public int ID { get; set; }
        public string ImgPath { get; set; }   // path to image
        public string Title { get; set; }  // title of image
        public string Desc { get; set; }  // description of image
        public bool Abandon { get; set; }  // is it an image of an abandoned Springfield?
        public bool Glitch { get; set; }   // is it the image of a glitch?
        public bool Cool { get; set; }  // is the image of something cool, interesting, clever, or pretty?

        // Foreign Keys

        // Navagation Properties

    }
}