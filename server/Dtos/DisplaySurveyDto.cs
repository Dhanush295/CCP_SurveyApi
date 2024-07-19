using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class DisplaySurveyDto
    {
        public int ID { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Address { get; set; }  = string.Empty;

        public string County { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;
    }
}