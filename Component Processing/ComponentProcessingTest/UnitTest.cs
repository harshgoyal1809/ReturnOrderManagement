using Component_Processing.Controllers;
using Component_Processing.Models;
using Component_Processing.Repositry;
using Moq;
using NUnit.Framework;
using System;

namespace ComponentProcessingTest
{
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var mock = new Mock<ComponentRepo>();
            ComponentRepo component = new ComponentRepo();
            ProcessResponse r = new ProcessResponse();
            ProcessRequest p = new ProcessRequest();
            p.Name = "Harsh";
            p.ContactNumber = 7894561230;
            p.CreditCardNumber = 1111444477778888;
            p.ComponentType = "Integral";
            p.ComponentName = "IC";
            p.Quantity = 2;
            p.IsPriorityRequest = true;

            r.RequestId = 0;
            r.DateOfDelivery = DateTime.Now.AddDays(2);
            r.ProcessingCharge = 1400;
            r.PackagingandDeliveryCharge = 600;
            Assert.NotNull(component.GetResponse(p.Name, p.ContactNumber, p.CreditCardNumber, p.ComponentType, p.ComponentName, p.Quantity, p.IsPriorityRequest));
        }

        [Test]
        public void Test2()
        {
            var mock = new Mock<ComponentRepo>();
            ComponentRepo component = new ComponentRepo();
            ProcessResponse r = new ProcessResponse();
            ProcessRequest p = new ProcessRequest();
            p.Name = "Narne";
            p.ContactNumber = 0123456789;
            p.CreditCardNumber = 1111444444448888;
            p.ComponentType = "Integral";
            p.ComponentName = "Circuit";
            p.Quantity = 1;
            p.IsPriorityRequest = false;

            r.RequestId = 0;
            r.DateOfDelivery = DateTime.Now.AddDays(5);
            r.ProcessingCharge = 500;
            r.PackagingandDeliveryCharge = 300;
            Assert.NotNull(component.GetResponse(p.Name, p.ContactNumber, p.CreditCardNumber, p.ComponentType, p.ComponentName, p.Quantity, p.IsPriorityRequest));
        }

        [Test]
        public void Test3()
        {
            var mock = new Mock<ComponentRepo>();
            ComponentRepo component = new ComponentRepo();
            ProcessResponse r = new ProcessResponse();
            ProcessRequest p = new ProcessRequest();
            p.Name = "Anonymous";
            p.ContactNumber = 7894561230;
            p.CreditCardNumber = 1111222233334444;
            p.ComponentType = "Accessory";
            p.ComponentName = "Charger";
            p.Quantity = 1;

            r.RequestId = 0;
            r.DateOfDelivery = DateTime.Now.AddDays(5);
            r.ProcessingCharge = 300;
            r.PackagingandDeliveryCharge = 150;
            Assert.NotNull(component.GetResponse(p.Name, p.ContactNumber, p.CreditCardNumber, p.ComponentType, p.ComponentName, p.Quantity, p.IsPriorityRequest));
        }
    }
}
