using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutoReservation.Dal;
using AutoReservation.Service.Wcf;
using AutoReservation.Common.DataTransferObjects;
namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;

        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        {
            AutoDto autoOld = Target.LoadAuto(1).ConvertToDto();
            AutoDto autoDtoCopy = (AutoDto)autoOld.Clone();
            
            autoDtoCopy.Marke = "Königsegg";
            autoDtoCopy.AutoKlasse = AutoKlasse.Luxusklasse;



            target.UpdateAuto(autoDtoCopy.ConvertToEntity(), autoOld.ConvertToEntity());
            Assert.AreEqual(autoDtoCopy.Marke, Target.LoadAuto(autoOld.Id).Marke);
            
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            //Kunde kundeNew = new Kunde();
            //Dal.Kunde kundeOld = target.LoadKunde(1);

            //kundeNew.Vorname = "testKundenVorname";
            //kundeNew.Nachname = "testKundenNachname";
            //kundeNew.Id = kundeOld.Id;
            //kundeNew.Geburtsdatum = kundeOld.Geburtsdatum;
            //kundeNew.Reservations = kundeOld.Reservations;
            
            //target.UpdateKunde(kundeOld, kundeNew);
            //Assert.AreNotEqual(kundeNew, kundeOld);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            
            //Auto autoNew = new Auto();
            //autoNew.Id = 1;
            //autoNew.Marke = "testMarke";
            //Reservation resOld = target.LoadReservation(1);
            //Reservation resNew = new Reservation();
            //res.Auto = autoNew;

            //target.UpdateReservation()
            //target.UpdateKunde(kundeOld, kundeNew);
            //Assert.AreNotEqual(kundeNew, kundeOld);
        
        }

    }
}
