using System;
using MyCrudAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace MyCrudAPI.Controllers
{
    public class CrudMVCController : Controller
    {
        // GET: ALL Data In Database  CrudMVC
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Studenttbl> emp_list = new List<Studenttbl>();
            client.BaseAddress = new Uri("https://localhost:44393/API/CrudAPI");
            var response = client.GetAsync("CrudAPI");
            response.Wait();
            var test=response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Studenttbl>>();
                display.Wait();
                emp_list=display.Result;
            }
            return View(emp_list);
        }

        //Create Action Method
        public ActionResult Create()
        {
            return View();
        }

        //Create Action Post Method
        [HttpPost]
        public ActionResult Create(Studenttbl emp)
        {
            List<Studenttbl> emp_list = new List<Studenttbl>();
            client.BaseAddress = new Uri("https://localhost:44393/API/CrudAPI");
            var response = client.PostAsJsonAsync<Studenttbl>("CrudAPI",emp);
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
               return RedirectToAction("Index");
            }
            return View();
        }

        //Details Action Method
        public ActionResult Details(int id)
        {
            Studenttbl e = null;
            client.BaseAddress = new Uri("https://localhost:44393/API/CrudAPI");
            var response = client.GetAsync("CrudAPI?id="+ id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Studenttbl>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        public ActionResult Edit(int id)
        {
            Studenttbl e = null;
            client.BaseAddress = new Uri("https://localhost:44393/API/CrudAPI");
            var response = client.GetAsync("CrudAPI?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Studenttbl>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Studenttbl s)
        {
            client.BaseAddress = new Uri("https://localhost:44393/API/CrudAPI");
            var response = client.PutAsJsonAsync<Studenttbl>("CrudAPI", s);
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            Studenttbl s = null;
            client.BaseAddress = new Uri("https://localhost:44393/API/CrudAPI");
            var response = client.GetAsync("CrudAPI?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Studenttbl>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44393/API/CrudAPI");
            var response = client.DeleteAsync("CrudAPI/" +id.ToString());
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}