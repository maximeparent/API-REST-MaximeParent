using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public class Column
{
    public long id { get; set; }
    public string type_column { get; set; }
    public long number_floors { get; set; }
    public string status { get; set; }
    public string information { get; set; }
    public string notes { get; set; }
    public long battery_id { get; set; }
    public Battery batteries { get; set; }
    public List<Elevator> elevators { get; set; }
}