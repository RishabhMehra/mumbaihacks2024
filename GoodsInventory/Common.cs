using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GoodsInventory
{
    public class Common
    {
        public DataTable TransposeTable(DataTable inputTable, string firstColName, string secondColName)
        {
            DataTable transposedTable = new DataTable();
            transposedTable.Columns.Add(firstColName);
            transposedTable.Columns.Add(secondColName);
            foreach (DataRow row in inputTable.Rows)
            {
                foreach (DataColumn column in inputTable.Columns)
                {
                    DataRow dr = transposedTable.NewRow();
                    dr[firstColName] = column.ColumnName;
                    dr[secondColName] = row[column.ColumnName];
                    transposedTable.Rows.Add(dr);
                }
            }
            return transposedTable;
        }
    }
}