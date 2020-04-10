using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public class Lead
{
public long id { get; set; }
public string name { get; set; }
public long phone { get; set; }
public string email { get; set; }
public string businessname { get; set; }
public string projectname { get; set; }
public string department { get; set; }
public string description { get; set; }
public string message { get; set; }
public DateTime date { get; set; }
}