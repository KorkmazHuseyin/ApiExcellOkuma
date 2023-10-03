using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellOkuma.Api.Dto
{
    public class KurumDTO
    {
        public string Sehir { get; set; }
        public decimal ResmiKurumSayisi { get; set; }
        public decimal OzelKurumSayisi { get; set; }
        public decimal KurumToplam { get; set; }
    }
}
