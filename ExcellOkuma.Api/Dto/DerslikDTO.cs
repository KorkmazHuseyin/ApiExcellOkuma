using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellOkuma.Api.Dto
{
    public class DerslikDTO
    {
        
        public string Sehir { get; set; }
        public decimal DerslikResmi { get; set; }
        public decimal DerslikOzel { get; set; }
        public decimal DerslikToplam { get; set; }
    }
}
