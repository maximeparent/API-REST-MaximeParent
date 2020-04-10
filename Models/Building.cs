using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

public class Building
{
    public long id { get; set; }
    public string building_name { get; set; }
    public string building_admin_name { get; set; }
    public string building_admin_email { get; set; }
    public string building_admin_phone { get; set; }
    public string technical_contact_fullname { get; set; }
    public string technical_contact_email { get; set; }
    public string technical_contact_phone { get; set; }
    public long customer_id { get; set; }
    public long adress_id { get; set; }
    public long user_id { get; set; }
    public float longitude { get; set; }
    public float latitude { get; set; }
    public List<Battery> batteries { get; set; }
}