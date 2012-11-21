using System;
using System.Collections.Generic;
using System.Linq;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.Testing
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
            List<Auto> autos = Target.GetAutos();
            var testMarke = "göppel";
            Assert.IsFalse(autos.Exists(a => a.Marke == testMarke));
            Auto auto = autos[0];
            auto.Marke = testMarke;
            Target.UpdateAuto(Target.GetAutos()[0], auto);
            Assert.AreEqual(testMarke, Target.GetAuto(auto.Id).Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            var kunden = Target.GetKunden();
            var testVorname = "sepp";
            Assert.IsFalse(kunden.Exists(a => a.Vorname == testVorname));
            var kunde = kunden[0];
            kunde.Vorname = testVorname;
            Target.UpdateKunde(Target.GetKunden()[0], kunde);
            Assert.AreEqual(testVorname, Target.GetKunde(kunde.Id).Vorname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            var reservationen = Target.GetReservationen();
            var reservation = reservationen[0];
            var testdate = DateTime.UtcNow;
            Assert.IsFalse(reservationen.Exists(r => r.Bis == testdate));
            reservation.Bis = testdate;
            Target.UpdateReservation(Target.GetReservationen()[0], reservation);
            Assert.AreEqual(testdate.ToString(), Target.GetReservation(reservation.ReservationNr).Bis.ToString());
        }
    }
}
