using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public class Elevator
{
    public long id { get; set; }
    public string serial_number { get; set; }
    public string model { get; set; }
    public string type_elevator { get; set; }
    public string status { get; set; }
    public DateTime commissioning_date { get; set; }
    public DateTime inspection_date { get; set; }
    public string certificate_inspection { get; set; }
    public string information { get; set; }
    public string notes { get; set; }
    public long column_id { get; set; }
    public Column columns { get; set; }
}