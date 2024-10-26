using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GoodsInventory
{
    public class IngrediantsDAL : DAL
    {
        //public DataTable GetVerticalDetail(int verticalId)
        //{
        //    Vertical vertical = new Vertical();
        //    Parameters.AddWithValue("VerticalId", verticalId);
        //    Parameters.AddWithValue("VerticalName", DBNull.Value);
        //    Parameters.AddWithValue("AbbreviationId", DBNull.Value);
        //    Parameters.AddWithValue("IsActive", DBNull.Value);

        //    var dr = GetExecuteReader("vts.spGetVertical");
        //    try
        //    {
        //        if (dr.Read())
        //        {
        //            vertical.VerticalId = Convert.ToInt32(dr["VerticalId"]);
        //            vertical.VerticalName = Convert.ToString(dr["VerticalName"]);
        //            vertical.AbbreviationId = Convert.ToInt32(dr["AbbreviationId"]);
        //            vertical.AbbreviationName = Convert.ToString(dr["AbbreviationName"]);
        //            vertical.CreatedBy = Convert.ToString(dr["CreatedBy"]);
        //            vertical.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
        //            vertical.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
        //            vertical.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
        //            vertical.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //        }
        //    }
        //    finally
        //    {
        //        if (dr != null && dr.IsClosed != true)
        //            dr.Close();
        //    }
        //    return vertical;
        //}
    }
}