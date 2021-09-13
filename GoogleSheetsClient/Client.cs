using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using GoogleSheets.DTO;

namespace GoogleSheets {
    public class Client {
        protected static readonly string GOOGLE_SHEETS = @"https://sheets.googleapis.com/v4/spreadsheets/";
        protected static readonly string PROPERTIES_REQUEST = @"fields=sheets.properties";
        protected static readonly string VALUES_REQUEST = @"/values/";

        public string TableID = @"1V_pEYllNh1ByuQAqf5fuWRXKiZ8LGdl4Uu6HpAQkJRE";
        public string ApiKey = @"AIzaSyATiizTDm6ihCc8cwEY1kZaycUpKvM6sEs";

        public Client(string TableID, string ApiKey) {
            this.TableID = TableID;
            this.ApiKey = ApiKey;
        }

        public Client() {}

        protected string InvokeRequest(string uri) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream)) {
                return reader.ReadToEnd();
            }
        }


        public List<string> GetSheetsNames() {
            string request = GOOGLE_SHEETS + TableID + "?" + "key=" + ApiKey + "&" + PROPERTIES_REQUEST;

            string response = InvokeRequest(request);

            var requestHandler = JsonConvert.DeserializeObject<RequestHandlerForList>(response);

            return requestHandler.sheets.Select(x => x.properties.title).ToList();
        }

        public SheetDataTable GetSheetValues(SheetDescriptor sheet, string startCell = "A1") {
            string request = GOOGLE_SHEETS + TableID + VALUES_REQUEST + Uri.EscapeDataString(sheet.title) + "!" + startCell + ":" + sheet.gridProperties.rowCount + "?" + "key=" + ApiKey;
            string response = InvokeRequest(request);
            return JsonConvert.DeserializeObject<SheetDataTable>(response);
        }

    }
}
