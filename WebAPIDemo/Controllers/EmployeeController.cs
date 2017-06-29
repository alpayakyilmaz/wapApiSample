using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;
using System.Runtime.Serialization;


namespace WebAPIDemo.Controllers
{
    [Serializable]  
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employees> Get()
        
        {
          EmployeeDbEntities db = new EmployeeDbEntities();
          return db.Employees.ToList();
           
        }

        public Employees Get(int id)
        {
            EmployeeDbEntities db = new EmployeeDbEntities();
            return db.Employees.FirstOrDefault(x => x.ID == id);

        }

        public HttpResponseMessage Post([FromBody] Employees employee)
        {
            try
            {
                using (EmployeeDbEntities db = new EmployeeDbEntities())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
       
        }
    }
}
