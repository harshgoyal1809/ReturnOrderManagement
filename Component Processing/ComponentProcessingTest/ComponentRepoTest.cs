using Component_Processing.Controllers;
using Component_Processing.Models;
using Component_Processing.Repositry;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;

namespace ComponentProcessingTest
{
    public class ComponentRepoTest
    {
        
        [SetUp]
        public void Setup()
        {
        }
        public void ComponentRepo()
        { }
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
            p.CreditLimit = 5000;
            p.ComponentType = "Integral";
            p.ComponentName = "IC";
            p.Quantity = 2;
            p.IsPriorityRequest = true;

            r = component.GetResponse(p.Name, p.ContactNumber, p.CreditCardNumber, p.CreditLimit, p.ComponentType, p.ComponentName, p.Quantity, p.IsPriorityRequest);
            Assert.NotNull(r);
            Assert.AreEqual(0, r.RequestId);
            Assert.AreEqual(1400.0, r.ProcessingCharge);
            Assert.AreEqual(600.0, r.PackagingandDeliveryCharge);
            Assert.AreEqual("3600", component.GetCompletion(r.RequestId, p.CreditCardNumber, p.CreditLimit, r.ProcessingCharge));
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
            p.CreditLimit = 800;
            p.ComponentType = "Integral";
            p.ComponentName = "Circuit";
            p.Quantity = 1;
            p.IsPriorityRequest = false;
           
            r = component.GetResponse(p.Name, p.ContactNumber, p.CreditCardNumber, p.CreditLimit, p.ComponentType, p.ComponentName, p.Quantity, p.IsPriorityRequest);
            Assert.NotNull(r);
            Assert.AreEqual(0, r.RequestId);
            Assert.AreEqual(500.0, r.ProcessingCharge);
            Assert.AreEqual(300.0, r.PackagingandDeliveryCharge);
            Assert.AreEqual("300", component.GetCompletion(r.RequestId, p.CreditCardNumber, p.CreditLimit, r.ProcessingCharge));
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
            p.CreditLimit = 1000;
            p.ComponentType = "Accessory";
            p.ComponentName = "Charger";
            p.Quantity = 1;

            r = component.GetResponse(p.Name, p.ContactNumber, p.CreditCardNumber, p.CreditLimit, p.ComponentType, p.ComponentName, p.Quantity, p.IsPriorityRequest);
            Assert.NotNull(r);
            Assert.AreEqual(0, r.RequestId);
            Assert.AreEqual(300.0, r.ProcessingCharge);
            Assert.AreEqual(150.0, r.PackagingandDeliveryCharge);
            Assert.AreEqual("700", component.GetCompletion(r.RequestId, p.CreditCardNumber, p.CreditLimit, r.ProcessingCharge));
        }

        [Test]
        public void Test4()
        {
            var mock = new Mock<ComponentRepo>();
            ComponentRepo component = new ComponentRepo();
            ProcessResponse r = new ProcessResponse();
            ProcessRequest p = new ProcessRequest();
            p.Name = "Vishesh Sharma";
            p.ContactNumber = 8791307177;
            p.CreditCardNumber = 7410852096302486;
            p.CreditLimit = 2500;
            p.ComponentType = "Accessory";
            p.ComponentName = "Battery";
            p.Quantity = 1;

            r = component.GetResponse(p.Name, p.ContactNumber, p.CreditCardNumber, p.CreditLimit, p.ComponentType, p.ComponentName, p.Quantity, p.IsPriorityRequest);
            Assert.NotNull(r);
            Assert.AreNotEqual(1, r.RequestId);
            Assert.AreNotEqual(500.0, r.ProcessingCharge);
            Assert.AreNotEqual(650.0, r.PackagingandDeliveryCharge);
            Assert.AreNotEqual("1200", component.GetCompletion(r.RequestId, p.CreditCardNumber, p.CreditLimit, r.ProcessingCharge));

        }
    }
}
