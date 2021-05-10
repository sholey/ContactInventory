using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            IEnumerable<mvcContactModel> contactList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contacts").Result;
            contactList = response.Content.ReadAsAsync<IEnumerable<mvcContactModel>>().Result;
            return View(contactList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcContactModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contacts/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcContactModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcContactModel contact)
        {
            if (contact.Id  == 0 )
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Contacts", contact).Result;
                TempData["Success"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Contacts/" + contact.Id, contact).Result;
                TempData["Success"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Contacts/" + id.ToString()).Result;
            TempData["Success"] = "Delete Successfully";
            return RedirectToAction("Index");
        }

    }
}