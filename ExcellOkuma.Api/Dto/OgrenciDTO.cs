using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellOkuma.Api.Dto
{
    public class OgrenciDTO
    {
        public string Sehir { get; set; }
        public decimal ResmiOgrenciErkek { get; set; }
        public decimal ResmiOgrenciKadin { get; set; }
        public decimal ResmiOgrenciToplam { get; set; }
        public decimal OzelOgrenciErkek { get; set; }
        public decimal OzelOgrenciKadin { get; set; }
        public decimal OzelOgrenciToplam { get; set; }
        public decimal ResmiOzelOgrenciToplam { get; set; }
    }
}
