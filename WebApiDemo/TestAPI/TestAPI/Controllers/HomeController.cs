using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using TestAPI.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace TestAPI.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        static async Task RunAsync(string uri)
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static async Task<IEnumerable<Employees>> GetEmployeesAsync(string path)
        {
            IEnumerable<Employees> emplyee = null;
            using (client = new HttpClient())
            {
                await RunAsync("http://localhost:49363/api/Employees");
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    string readTask = response.Content.ReadAsStringAsync().Result;
                    emplyee = JsonConvert.DeserializeObject<IEnumerable<Employees>>(readTask);
                }
            }
            return emplyee;
        }

        static async Task<bool> CreateEmployeeAsync(Employees employee)
        {
            using (client = new HttpClient())
            {
                await RunAsync("http://localhost:49363/api/Employees");
                HttpResponseMessage response = await client.PostAsJsonAsync("Employees", employee);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        static async Task<Employees> EditEmployeeDetail(string id)
        {
            Employees employee = null;

            using (client = new HttpClient())
            {
                await RunAsync("http://localhost:49363/");
                HttpResponseMessage response = await client.GetAsync($"api/Employees/{id}");
                if (response.IsSuccessStatusCode)
                {
                    employee = await response.Content.ReadAsAsync<Employees>();
                }
            }
            return employee;
        }

        static async Task<bool> EditEmployee(Employees employee)
        {
            using (client = new HttpClient())
            {
                await RunAsync("http://localhost:49363/");
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Employees/{employee.EmployeeID}", employee);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
        static async Task<bool> DeleteEmployeeAsync(string id)
        {
            using (client = new HttpClient())
            {
                await RunAsync("http://localhost:49363/");
                HttpResponseMessage response = await client.DeleteAsync($"api/Employees/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }


        public async Task<ActionResult> Index(string keyword = "")
        {
            IEnumerable<Employees> emplyee = await GetEmployeesAsync("Employees");
            var data = emplyee.Where(x => x.EmployeeID.StartsWith(keyword) || x.EmployeeName.StartsWith(keyword) || x.Department.StartsWith(keyword) || x.Salary.ToString().StartsWith(keyword)).ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employees employee)
        {
            if (await CreateEmployeeAsync(employee))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Edit(string id)
        {
            Employees employee = await EditEmployeeDetail(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Employees employee)
        {
            if (await EditEmployee(employee))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (await DeleteEmployeeAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


    }
}