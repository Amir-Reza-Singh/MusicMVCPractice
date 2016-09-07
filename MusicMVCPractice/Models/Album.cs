using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMVCPractice.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistID  { get; set; }
        public virtual Artist Artist { get; set; }
        public string Name { get;set; }
    }
}