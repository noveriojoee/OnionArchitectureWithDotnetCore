using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResvCo.Db;
using ResvCo.Models;
using Microsoft.EntityFrameworkCore;

namespace ResvCo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ApplicationContext _db;

        public ValuesController(ApplicationContext db){
            this._db = db;
        }

        [Route("~/api/gettesting")]
        [HttpPost]
        public String testingApi(){
            return "hai";
        }

        [Route("~/api/getband")]
        [HttpPost]
        public DbSet<Band> GetDataBand()
        {
            var result = this._db.Bands;

            return result;
        }

        [Route("~/api/insert")]
        [HttpPost]
        public Band InsertDataBand([FromBody]Band value)
        {
            this._db.Bands.Add(value);
            this._db.SaveChanges();
            return value;
        }
    }
}
