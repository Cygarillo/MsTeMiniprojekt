using System;
using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosTest()
        {
            Assert.AreEqual(3, new HashSet<int>(Target.GetAutos().ConvertAll(input => input.Id)).Count);
        }

        [TestMethod]
        public void KundenTest()
        {
            Assert.AreEqual(4, new HashSet<int>(Target.GetKunden().ConvertAll(input => input.Id)).Count);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            Assert.AreEqual(3, new HashSet<int>(Target.GetReservationen().ConvertAll(input => input.ReservationNr)).Count);
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {
            Assert.IsNotNull(Target.GetAuto(1));
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            Assert.IsNotNull(Target.GetKunde(1));
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            Assert.IsNotNull(Target.GetReservation(1));
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            Assert.IsNull(Target.GetReservation(-1));
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            try
            {
                Target.AddAuto(new AutoDto()
                                    {
                                        Id = 10,
                                        Marke = "BMW",
                                        AutoKlasse = AutoKlasse.Mittelklasse,
                                        Basistarif = 50,
                                        Tagestarif = 60
                                    });
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            try
            {
                Target.AddKunde(new KundeDto()
                {
                    Geburtsdatum = new DateTime(1980, 1, 4),
                    Id = 10,
                    Nachname = "Maulwurf",
                    Vorname = "Hans"
                });
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            try
            {
                Target.AddReservation(new ReservationDto()
                {
                    ReservationNr = 10,
                    Auto = Target.GetAuto(1),
                    Kunde = Target.GetKunde(1),
                    Von = DateTime.UtcNow,
                    Bis = DateTime.UtcNow.AddDays(5)
                });
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
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
