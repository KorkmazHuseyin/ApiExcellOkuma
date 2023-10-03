using ExcellOkuma.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellOkuma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
       

        [HttpGet("GetExcellData")]
        public ActionResult<IEnumerable<Dictionary<string, string>>> GetExcellData()
        {
            string filePath = "C:\\AnaOkulu\\AnaOkuluExcell.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                List<Dictionary<string, string>> excelData = new List<Dictionary<string, string>>();

                // Başlık satırını al
                List<string> headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Value?.ToString());
                }

                // Her bir şehir için başlık ve değerleri al
                for (int row = 2; row <= rowCount; row++)
                {
                    // Şehir adını al
                    string city = worksheet.Cells[row, 1].Value?.ToString();

                    // Şehir adı null ise veya boş ise döngüyü sonlandır
                    if (string.IsNullOrEmpty(city))
                    {
                        break;
                    }

                    // Şehir adı olan satır için verileri al
                    Dictionary<string, string> cityData = new Dictionary<string, string>();
                    for (int col = 1; col <= colCount; col++)
                    {
                        string header = headers[col - 1];
                        string cellValue = worksheet.Cells[row, col].Value?.ToString();
                        cityData.Add(header, cellValue);
                    }
                    excelData.Add(cityData);
                }

                return excelData;
            }
        }





        [HttpGet("DerslikData")]
        public ActionResult<DerslikDTO> DerslikData([FromQuery] string city)
        {
            string filePath = "C:\\AnaOkulu\\AnaOkuluExcell.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // Başlık satırını al
                List<string> headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Value?.ToString());
                }

                // İstenen şehre ait bilgileri bul
                int rowIndex = -1;
                for (int row = 2; row <= rowCount; row++)
                {
                    string currentCity = worksheet.Cells[row, 1].Value?.ToString(); // Şehir adı, 1. kolon
                    if (currentCity == city)
                    {
                        rowIndex = row;
                        break;
                    }
                }

                // Eğer şehir bulunamazsa NotFound döndür
                if (rowIndex == -1)
                {
                    return NotFound($"'{city}' şehri bulunamadı.");
                }

                // DerslikDTO'yu doldur
                DerslikDTO derslikData = new DerslikDTO
                {
                    Sehir = city,
                    DerslikResmi = Convert.ToDecimal(worksheet.Cells[rowIndex, 2].Value),
                    DerslikOzel = Convert.ToDecimal(worksheet.Cells[rowIndex, 3].Value),
                    DerslikToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 4].Value)
                };

                return derslikData;
            }
        }







        [HttpGet("KurumData")]
        public ActionResult<KurumDTO> KurumData([FromQuery] string city)
        {
            string filePath = "C:\\AnaOkulu\\AnaOkuluExcell.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // Başlık satırını al
                List<string> headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Value?.ToString());
                }

                // İstenen şehre ait bilgileri bul
                int rowIndex = -1;
                for (int row = 2; row <= rowCount; row++)
                {
                    string currentCity = worksheet.Cells[row, 1].Value?.ToString(); // Şehir adı, 1. kolon
                    if (currentCity == city)
                    {
                        rowIndex = row;
                        break;
                    }
                }

                // Eğer şehir bulunamazsa NotFound döndür
                if (rowIndex == -1)
                {
                    return NotFound($"'{city}' şehri bulunamadı.");
                }

                // KurumDTO'yu doldur
                KurumDTO kurumData = new KurumDTO
                {
                    Sehir = city,
                    ResmiKurumSayisi = Convert.ToDecimal(worksheet.Cells[rowIndex, 5].Value),
                    OzelKurumSayisi = Convert.ToDecimal(worksheet.Cells[rowIndex, 6].Value),
                    KurumToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 7].Value)
                };

                return kurumData;
            }
        }



        [HttpGet("OgrenciData")]
        public ActionResult<OgrenciDTO> OgrenciData([FromQuery] string city)
        {
            string filePath = "C:\\AnaOkulu\\AnaOkuluExcell.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // Başlık satırını al
                List<string> headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Value?.ToString());
                }

                // İstenen şehre ait bilgileri bul
                int rowIndex = -1;
                for (int row = 2; row <= rowCount; row++)
                {
                    string currentCity = worksheet.Cells[row, 1].Value?.ToString(); // Şehir adı, 1. kolon
                    if (currentCity == city)
                    {
                        rowIndex = row;
                        break;
                    }
                }

                // Eğer şehir bulunamazsa NotFound döndür
                if (rowIndex == -1)
                {
                    return NotFound($"'{city}' şehri bulunamadı.");
                }

                // OgrenciDTO'yu doldur
                OgrenciDTO ogrenciData = new OgrenciDTO
                {
                    Sehir = city,
                    ResmiOgrenciErkek = Convert.ToDecimal(worksheet.Cells[rowIndex, 11].Value),
                    ResmiOgrenciKadin = Convert.ToDecimal(worksheet.Cells[rowIndex, 12].Value),
                    ResmiOgrenciToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 13].Value),
                    OzelOgrenciErkek = Convert.ToDecimal(worksheet.Cells[rowIndex, 14].Value),
                    OzelOgrenciKadin = Convert.ToDecimal(worksheet.Cells[rowIndex, 15].Value),
                    OzelOgrenciToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 16].Value),
                    ResmiOzelOgrenciToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 17].Value)
                };

                return ogrenciData;
            }
        }




        [HttpGet("OgretmenData")]
        public ActionResult<OgretmenDTO> OgretmenData([FromQuery] string city)
        {
            string filePath = "C:\\AnaOkulu\\AnaOkuluExcell.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // Başlık satırını al
                List<string> headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Value?.ToString());
                }

                // İstenen şehre ait bilgileri bul
                int rowIndex = -1;
                for (int row = 2; row <= rowCount; row++)
                {
                    string currentCity = worksheet.Cells[row, 1].Value?.ToString(); // Şehir adı, 1. kolon
                    if (currentCity == city)
                    {
                        rowIndex = row;
                        break;
                    }
                }

                // Eğer şehir bulunamazsa NotFound döndür
                if (rowIndex == -1)
                {
                    return NotFound($"'{city}' şehri bulunamadı.");
                }

                // OgretmenDTO'yu doldur
                OgretmenDTO ogretmenData = new OgretmenDTO
                {
                    Sehir = city,
                    ResmiOgretmenErkek = Convert.ToDecimal(worksheet.Cells[rowIndex, 18].Value),
                    ResmiOgretmenKadin = Convert.ToDecimal(worksheet.Cells[rowIndex, 19].Value),
                    ResmiOgretmenToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 20].Value),
                    OzelOgretmenErkek = Convert.ToDecimal(worksheet.Cells[rowIndex, 21].Value),
                    OzelOgretmenKadin = Convert.ToDecimal(worksheet.Cells[rowIndex, 22].Value),
                    OzelOgretmenToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 23].Value),
                    ResmiOzelOgretmenToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 24].Value)
                };

                return ogretmenData;
            }
        }



        [HttpGet("SubeData")]
        public ActionResult<SubeDTO> SubeData([FromQuery] string city)
        {
            string filePath = "C:\\AnaOkulu\\AnaOkuluExcell.xlsx";

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // Başlık satırını al
                List<string> headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[1, col].Value?.ToString());
                }

                // İstenen şehre ait bilgileri bul
                int rowIndex = -1;
                for (int row = 2; row <= rowCount; row++)
                {
                    string currentCity = worksheet.Cells[row, 1].Value?.ToString(); // Şehir adı, 1. kolon
                    if (currentCity == city)
                    {
                        rowIndex = row;
                        break;
                    }
                }

                // Eğer şehir bulunamazsa NotFound döndür
                if (rowIndex == -1)
                {
                    return NotFound($"'{city}' şehri bulunamadı.");
                }

                // SubeDTO'yu doldur
                SubeDTO subeData = new SubeDTO
                {
                    Sehir = city,
                    ResmiSubeSayisi = Convert.ToDecimal(worksheet.Cells[rowIndex, 8].Value),
                    OzelSubeSayisi = Convert.ToDecimal(worksheet.Cells[rowIndex, 9].Value),
                    SubeToplam = Convert.ToDecimal(worksheet.Cells[rowIndex, 10].Value)
                };

                return subeData;
            }
        }


    }
}