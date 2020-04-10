using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

public class Customer
{
public long id { get; set; }
public DateTime creation_date { get; set; }
public string company_name { get; set; }
public string contact_fullname { get; set; }
public string contact_phone { get; set; }
public string company_email { get; set; }
public string company_description { get; set; }
public string service_technical_authority_fullname { get; set; }
public string service_technical_authority_phone { get; set; }
public string technical_manager_email { get; set; }
}