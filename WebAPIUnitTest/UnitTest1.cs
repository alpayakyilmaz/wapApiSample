using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIDemo.Controllers;
using EmployeeDataAccess;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.IO;
namespace WebAPIUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllEmployeeTest()
        {
            var testObject = GetAllEmployees();
            var controller = new EmployeeController();

            var result = controller.Get() as List<Employees>;
            Assert.AreEqual(testObject.Count, result.Count);


        }

        private List<Employees> GetAllEmployees()
        {
            var testEmployee = new List<Employees>();
            testEmployee.Add(new Employees { ID = 1, FirstName = "Test 1 Employee", LastName = "Test1 Employee Last Name", Gender = "Male", Salary = 1400 });
            testEmployee.Add(new Employees { ID = 2, FirstName = "Test 2 Employee", LastName = "Test2 Employee Last Name", Gender = "Female", Salary = 1200 });
            testEmployee.Add(new Employees { ID = 3, FirstName = "Test 3 Employee", LastName = "Test3 Employee Last Name", Gender = "Male", Salary = 900 });
            testEmployee.Add(new Employees { ID = 4, FirstName = "Test 4 Employee", LastName = "Test4 Employee Last Name", Gender = "Female", Salary = 1200 });

            return testEmployee;
        }


    }
}
