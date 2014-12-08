using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

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
            IEnumerable<AutoDto> autos = service.LoadAutos();
            Assert.IsNotNull(autos);
        }

        [TestMethod]
        public void KundenTest()
        {
            IEnumerable<KundeDto> kunden = service.LoadKunden();
            Assert.IsNotNull(kunden);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            IEnumerable<ReservationDto> res = service.LoadReservationen();
            Assert.IsNotNull(res);
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
            AutoDto newCar = new AutoDto { AutoKlasse = AutoKlasse.Standard, Marke = "Schlitten", Tagestarif = 77};
            service.AddAuto(newCar);
            Assert.IsTrue(service.LoadAutos().ToList().Contains(newCar));
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            KundeDto kunde = new KundeDto { Nachname = "Chlaus", Vorname = "Sami", Geburtsdatum = System.DateTime.Today.AddYears(-75) };
            service.AddKunde(kunde);
            Assert.IsTrue(service.LoadKunden().ToList().Contains(kunde));

        }

        [TestMethod]
        public void InsertReservationTest()
        {
            ReservationDto res = new ReservationDto { Auto = service.LoadAuto(1), Kunde = service.LoadKunde(1) };
            service.AddReservation(res);
            Assert.IsTrue(service.LoadReservationen().ToList().Contains(res));
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            AutoDto auto = service.LoadAuto(1);
            AutoDto modified = auto.Clone() as AutoDto;
            modified.Marke = "Jaguar";
            service.UpdateAuto(modified, auto);
            Assert.AreNotEqual(service.LoadAutos().ToList().Find(auto2 => auto2.Marke == "Jaguar").Marke, auto.Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            KundeDto kunde = service.LoadKunde(1);
            KundeDto modified = kunde.Clone() as KundeDto;
            modified.Nachname = "Mustermann";
            service.UpdateKunde(modified, kunde);
            Assert.AreNotEqual(service.LoadKunden().ToList().Find(client => client.Nachname == "Mustermann"), kunde.Nachname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            ReservationDto original = service.LoadReservation(1);
            ReservationDto modified = original.Clone() as ReservationDto;
            modified.bis = System.DateTime.Today.AddYears(12);
            service.ReservationUpdate(modified, original);
            Assert.AreNotEqual(service.LoadReservationen().ToList().Find(res => res.bis == System.DateTime.Today.AddYears(12)).bis, original.bis);
        }



        [TestMethod]
        [ExpectedException(typeof(AutoReservation.BusinessLayer.LocalOptimisticConcurrencyException<>), "Concurrency Exception occured")]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            AutoDto first = service.LoadAuto(1);
            AutoDto firstClone = first.Clone() as AutoDto;
            AutoDto second = service.LoadAuto(1);
            AutoDto secondClone = second.Clone() as AutoDto;
            firstClone.Marke = "supercar";
            secondClone.Marke = "hypercar";
            service.UpdateAuto(secondClone, second);
            service.UpdateAuto(firstClone, first);
        }

        [TestMethod]
        [ExpectedException(typeof(AutoReservation.BusinessLayer.LocalOptimisticConcurrencyException<>), "Concurrency Exception occured")]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            KundeDto first = service.LoadKunde(1);
            KundeDto firstClone = first.Clone() as KundeDto;
            KundeDto second = service.LoadKunde(1);
            KundeDto secondClone = second.Clone() as KundeDto;
            firstClone.Nachname = "Müller";
            secondClone.Nachname = "Meier";
            service.UpdateKunde(secondClone, second);
            service.UpdateKunde(firstClone, first);


        }

        [TestMethod]
        [ExpectedException(typeof(AutoReservation.BusinessLayer.LocalOptimisticConcurrencyException<>), "Concurrency Exception occured")]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            ReservationDto first = service.LoadReservation(1);
            ReservationDto firstClone = first.Clone() as ReservationDto;
            ReservationDto second = service.LoadReservation(1);
            ReservationDto secondClone = second.Clone() as ReservationDto;
            firstClone.bis = System.DateTime.Today.AddYears(1);
            secondClone.bis = System.DateTime.Today.AddYears(2);
            service.ReservationUpdate(secondClone, second);
            service.ReservationUpdate(firstClone, first);

        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            service.DeleteKunde(1);
            Assert.IsNull(service.LoadKunde(1));
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            service.DeleteAuto(1);
            Assert.IsNull(service.LoadAuto(1));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            service.DeleteReservation(1);
            Assert.IsNull(service.LoadReservation(1));
        }
    }
}
