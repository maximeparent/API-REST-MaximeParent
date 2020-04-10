using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public class Intervention
{
    public long id { get; set; }
    public long author_id { get; set; }
    public long customer_id { get; set; }
    public long building_id { get; set; }
    public long battery_id { get; set; }
    public long? column_id { get; set; } = null;
    public long? elevator_id { get; set; } = null;
    public long? employee_id { get; set; } = null;
    public DateTime? start_date { get; set; } = null;
    public DateTime? end_date { get; set; } = null;
    public string result { get; set; }
    public string report { get; set; }
    public string status { get; set; }
}


    // public long? column_id { get; set; } = Convert.IsDBNull(row["column"]) ? null : (long?) Convert.ToInt32("column");
    // int stockvalue = (Intervention["StockValue"] as int?) ?? 0;
    // public long? column_id = (long?)(!Convert.IsDBNull(column_id) ? column_id : null);