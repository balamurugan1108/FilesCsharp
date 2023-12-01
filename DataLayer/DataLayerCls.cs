using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using Newtonsoft.Json.Linq;

namespace DataLayer
{
    public class DataLayerCls : IDataLayerCls
    {
        private readonly JsonDbContext _jsonDbContext;
        public DataLayerCls(JsonDbContext jsonDbContext)
        {
            _jsonDbContext = jsonDbContext;
        }

        public object JsonTOEXcel()
        {
            string filepath = @"\\192.168.0.115\vaf\New folder\sam.json";
            string read = File.ReadAllText(filepath);
            var jsonFile = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(read);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Data");

                int row = 1;
                int col = 1;

                foreach (var key in jsonFile[0].Keys)
                {
                    worksheet.Cells[row, col].Value = key;
                    col++;
                }
                row++;
                foreach (var data in jsonFile)
                {
                    col = 1;
                    foreach (var value in data.Values)
                    {
                        worksheet.Cells[row, col].Value = value;
                        col++;
                    }
                    row++;
                }
                string savepath = "E:\\C#\\Output.xlsx";
                package.SaveAs(new FileInfo(savepath));
                return savepath;
            }
        }


        public object ExcelToJson()
        {
            string filepath = @"\\192.168.0.115\vaf\New folder\sam.json";
            string read = File.ReadAllText(filepath);
            var jsonFile = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(read);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo("E:\\C#\\Output.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                List<Dictionary<string, object>> jsonList = new List<Dictionary<string, object>>();

                for (int row = 2; row <= rowCount; row++)
                {
                    var data = new Dictionary<string, object>();
                    for (int col = 1; col <= colCount; col++)
                    {
                        string key = worksheet.Cells[1, col].Value.ToString();
                        object value = worksheet.Cells[row, col].Value;
                        data[key] = value;
                    }
                    jsonList.Add(data);
                }

                string json = JsonConvert.SerializeObject(jsonList, Formatting.Indented);
                File.WriteAllText("E:\\C#\\Output.json", json);
                return json;
            }
        }
    }
}
