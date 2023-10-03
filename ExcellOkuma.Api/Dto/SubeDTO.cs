using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellOkuma.Api.Dto
{
    public class SubeDTO
    {
        public string Sehir { get; set; }
        public decimal ResmiSubeSayisi { get; set; }
        public decimal OzelSubeSayisi { get; set; }
        public decimal SubeToplam { get; set; }
    }
}
