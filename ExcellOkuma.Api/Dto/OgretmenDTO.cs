using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellOkuma.Api.Dto
{
    public class OgretmenDTO
    {
        public string Sehir { get; set; }
        public decimal ResmiOgretmenErkek { get; set; }
        public decimal ResmiOgretmenKadin { get; set; }
        public decimal ResmiOgretmenToplam { get; set; }
        public decimal OzelOgretmenErkek { get; set; }
        public decimal OzelOgretmenKadin { get; set; }
        public decimal OzelOgretmenToplam { get; set; }
        public decimal ResmiOzelOgretmenToplam { get; set; }
    }
}
