using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Выключает предупреждение для названий полей - нужно для правильной работы десериалайзера
/// </summary>
#pragma warning disable IDE1006

namespace GoogleSheets.DTO {
    public class SheetDataTable {
        public string range { get; set; }
        public string majorDimension { get; set; }
        public List<List<string>> values { get; set; }

        public int RowsCount { get { return values.Count; } }

        private int _columnsCount = 0;
        public int ColumnsCount {
            get {
                if (_columnsCount != 0)
                    return _columnsCount;
                values.ForEach(x => _columnsCount = Math.Max(_columnsCount, x.Count));
                return _columnsCount;
            }
        }
        public string GetValue(int column, int row) {
            var getted_row = values.ElementAtOrDefault(row);
            if (getted_row == null)
                return "";
            var getted_val = getted_row.ElementAtOrDefault(column);
            if (getted_val == null)
                return "";
            return getted_val;
        }
    }
    public class SheetGridProperties {
        public int rowCount { get; set; }
        public int columnCount { get; set; }
    }

    public class SheetDescriptor {
        public int sheetId { get; set; }
        public string title { get; set; }
        public int index { get; set; }
        public SheetGridProperties gridProperties { get; set; }
    }
    public class RequestHandlerForProperties {
        public SheetDescriptor properties { get; set; }
    }
    class RequestHandlerForList {
        public List<RequestHandlerForProperties> sheets { get; set; }
    }
}

#pragma warning restore IDE1006