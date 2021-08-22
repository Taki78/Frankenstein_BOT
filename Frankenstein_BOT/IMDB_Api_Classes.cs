using System;
using System.Collections.Generic;
using System.Text;

namespace Frankenstein_BOT
{
    public class MovieDetail
    {
        public string id { get; set; }
        public string resultType { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class MovieDetailRoot
    {
        public string searchType { get; set; }
        public string expression { get; set; }
        public List<MovieDetail> results { get; set; }
        public string errorMessage { get; set; }
    }

    public class Subtitle
    {
        public object seasonNumber { get; set; }
        public string id { get; set; }
        public string rate { get; set; }
        public string title { get; set; }
        public string owner { get; set; }
        public string comment { get; set; }
        public string link { get; set; }
    }

    public class Subtitle_Root
    {
        public string imDbId { get; set; }
        public string title { get; set; }
        public string fullTitle { get; set; }
        public string type { get; set; }
        public string year { get; set; }
        public List<Subtitle> subtitles { get; set; }
        public string errorMessage { get; set; }
    }

}
