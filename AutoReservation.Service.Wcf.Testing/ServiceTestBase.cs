using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }
        AutoReservationService service = new AutoReservationService();
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosTest()
        {

        }

        [TestMethod]
        public void KundenTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void ReservationenTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {

            AutoDto auto = service.LoadAuto(3);
            Assert.IsNotNull(auto);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            KundeDto kunde = service.LoadKunde(3);
            Assert.IsNotNull(kunde);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            ReservationDto res = service.LoadReservation(1);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            ReservationDto res = service.LoadReservation(-1);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            AutoDto newCar = new AutoDto();
            newCar.AutoKlasse = AutoKlasse.Standard;
            newCar.Marke = "Toyota";
            newCar.Tagestarif = 10;
            newCar.Id = 99;

            service.AddAuto(newCar);
            Assert.AreEqual(service.LoadAuto(99).Marke, newCar.Marke);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            KundeDto kunde = new KundeDto();
            kunde.Nachname = "Chlaus";
            kunde.Vorname = "Sami";
            kunde.Id = 55;
            kunde.Geburtsdatum = System.DateTime.Today.AddYears(-75);

            service.AddKunde(kunde);
            Assert.IsNotNull(service.LoadKunde(55));

        }

        [TestMethod]
        public void InsertReservationTest()
        {
            ReservationDto res = new ReservationDto();
            res.Auto = service.LoadAuto(1);
            res.Kunde = service.LoadKunde(1);
            

            service.AddReservation(res);
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            KundeDto kunde = service.LoadKunde(1);
            KundeDto modified = kunde.Clone() as KundeDto;
            modified.Nachname = "Mustermann";

            service.UpdateKunde(modified, kunde);

            Assert.AreNotEqual(kunde.Nachname, modified.Nachname);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }
    }
}
