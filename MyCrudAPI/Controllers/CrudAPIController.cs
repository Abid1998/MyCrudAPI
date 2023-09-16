using MyCrudAPI.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;



namespace MyCrudAPI.Controllers
{
    public class CrudAPIController : ApiController
    {
        StudentEntities3 db = new StudentEntities3();
        //Get All Data In DataBase 
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployee()
        {
            List<Studenttbl> list = db.Studenttbls.ToList();
            return Ok(list);
        }

        //Get Singal Data In DataBase 
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.Studenttbls.Where(model => model.id == id).FirstOrDefault();
            return Ok(emp);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Studenttbl e)
        {
            try
            {
                // Your code to update the entries using Entity Framework goes here
                db.Studenttbls.Add(e);
                db.SaveChanges();
             
            }
            catch (DbUpdateException ex)
            {
               return BadRequest(ex.Message);
            }
            return Ok();

        }

        // Edit Method One 
        [System.Web.Http.HttpPut]
        public IHttpActionResult StdUpdate(Studenttbl s)
        {
            try
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // Edit Method Two 
        //[System.Web.Http.HttpPut]
        //public IHttpActionResult StdUpdate(Studenttbl s)
        //{
        //    try
        //    {
        //        // Your code to update the entries using Entity Framework goes here
        //       var std=db.Studenttbls.Where(Model => Model.id == s.id).FirstOrDefault();
        //        if (std!=null)
        //        {
        //            std.id = s.id;
        //            std.fname = s.fname;
        //            std.lname = s.lname;
        //            std.email = s.email;
        //            std.phone = s.phone;
        //            std.address = s.address;
        //            std.date = s.date;
        //            std.Stime = s.Stime;
        //            std.Status = s.Status;
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //       return BadRequest(ex.Message);
        //    }
        //    return Ok();

        //}

        // Delete Method 
        [System.Web.Http.HttpDelete]
        public IHttpActionResult StdDelete(int id)
        {
            try
            {
                var std = db.Studenttbls.Where(Model => Model.id == id).FirstOrDefault();
                db.Entry(std).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
