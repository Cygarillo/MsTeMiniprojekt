using System;
using System.Collections.Generic;
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
            Assert.IsTrue(autos.Exists(a => a.Marke == testMarke));
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            //var kunden = Target.GetKunden();
            //var testName = "göppel";
            //Assert.IsFalse(autos.Exists(a => a.Marke == testMarke));
            //var kunde = kunden[0];
            //auto.Marke = testMarke;
            //Target.UpdateAuto(Target.GetAutos()[0], auto);
            //Assert.IsTrue(autos.Exists(a => a.Marke == testMarke))
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            List<Auto> autos = Target.GetAutos();
            var testMarke = "göppel";
            Assert.IsFalse(autos.Exists(a => a.Marke == testMarke));
            Auto auto = autos[0];
            auto.Marke = testMarke;
            Target.UpdateAuto(Target.GetAutos()[0], auto);
            Assert.IsTrue(autos.Exists(a => a.Marke == testMarke))
        }

    }
}
