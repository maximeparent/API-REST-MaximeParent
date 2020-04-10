using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public class Battery
{
    public long id { get; set; }
    public string type_battery { get; set; }
    public string status { get; set; }
    public DateTime commissioning_date { get; set; }
    public DateTime last_inspection_date { get; set; }
    public string certificate_operations { get; set; }
    public string information { get; set; }
    public string notes { get; set; }
    public long employee_id { get; set; }
    public long building_id { get; set; }
    public Building buildings { get; set; }
    public List<Column> columns { get; set; }
}