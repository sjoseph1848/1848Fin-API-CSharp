using System;
using System.Collections.Generic;
using System.Text;

namespace Fin.BL.Models
{
    public class IndexDto
    {
        public string symbol { get; set; }

        public IndexDetailDto[] Historical { get; set; }
    }
}
