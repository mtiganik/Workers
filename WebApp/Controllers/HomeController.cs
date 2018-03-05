using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.IO;
using System.Web;
using System.Text;
using System.Globalization;
using Domain;
using DAL.App;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        Database _db = new Database();
        
        // GET all workers to DB object. 
        public void getData()
        {
            bool _firstLine = true;
            try
            {
                using (StreamReader sr = new StreamReader("../WorkersCSV.csv", Encoding.GetEncoding("iso-8859-1")))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        if (_firstLine)
                        {
                            _firstLine = false;
                        }
                        else
                        {
                            _db.AddWorker(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // GET: Home
        public ViewResult Index(string filter, string department)
        {
            // GET workers DATA only first time
            if (_db.workers.Count < 1)
            {
                getData();
            }

            var workers = _db.workers;
            if (string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(department))
            {
                ViewBag.Sort = "Down";
                return View(workers);
            }
            else if (!string.IsNullOrEmpty(department))
            {
                workers = workers.Where(s => s.WorkerDepartment.DepartmentName.ToUpper().Contains(department.ToUpper())).ToList();
                return View(workers);
            }
            else 
            {
                if(filter.Contains("Down"))
                {
                    ViewBag.Sort = "Up";
                    switch (filter.Split(' ')[0])
                    {
                        case ("firstName"):
                            workers = workers.OrderBy(w => w.FirstName).ToList();
                            break;
                        case ("lastName"):
                            workers = workers.OrderBy(w => w.LastName).ToList();
                            break;
                        case("contractType"):
                            workers = workers.OrderBy(w => w.WorkerContractType).ToList();
                            break;
                        case ("contractFrom"):
                            workers = workers.OrderByDescending(w => w.ContractFrom).ToList();
                            break;
                        case ("contractUntil"):
                            workers = workers.OrderByDescending(w => w.ContractUntil).ToList();
                            break;
                        case ("department"):
                            workers = workers.OrderBy(w => w.WorkerDepartment.DepartmentName).ToList();
                            break;
                        case ("position"):
                            workers = workers.OrderBy(w => w.WorkerPosition.PositionName).ToList();
                            break;
                        default:
                            workers = workers.OrderBy(w => w.LastName).ToList();
                            break;
                    }
                }
                else
                {
                    ViewBag.Sort = "Down";
                    switch (filter.Split(' ')[0])
                    {
                        case ("firstName"):
                            workers = workers.OrderByDescending(w => w.FirstName).ToList();
                            break;
                        case ("lastName"):
                            workers = workers.OrderByDescending(w => w.LastName).ToList();
                            break;
                        case ("contractType"):
                            workers = workers.OrderByDescending(w => w.WorkerContractType).ToList();
                            break;
                        case ("contractFrom"):
                            workers = workers.OrderBy(w => w.ContractFrom).ToList();
                            break;
                        case ("contractUntil"):
                            workers = workers.OrderBy(w => w.ContractUntil).ToList();
                            break;
                        case ("department"):
                            workers = workers.OrderByDescending(w => w.WorkerDepartment.DepartmentName).ToList();
                            break;
                        case ("position"):
                            workers = workers.OrderByDescending(w => w.WorkerPosition.PositionName).ToList();
                            break;
                        default:
                            workers = workers.OrderByDescending(w => w.LastName).ToList();
                            break;
                    }

                }
                
                return View(workers);
            }
            
        }

       
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}
