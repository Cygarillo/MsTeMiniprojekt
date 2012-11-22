using System;
using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal;
using AutoReservation.Service.Wcf;
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
            try
            {
                var original = Target.GetAuto(1);
                var modified = (AutoDto)original.Clone();
                modified.Tagestarif += 10;
                Target.UpdateAuto(original, modified);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            try
            {
                var original = Target.GetKunde(1);
                var modified = (KundeDto)original.Clone();
                modified.Nachname += "a";
                Target.UpdateKunde(original, modified);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            try
            {
                var original = Target.GetReservation(1);
                var modified = (ReservationDto)original.Clone();
                modified.Bis = modified.Bis.AddDays(3);
                Target.UpdateReservation(original, modified);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<LocalOptimisticConcurrencyException<Auto>>), "")]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            using(var context = new AutoReservationEntities())
            {
                var auto = Target.GetAuto(1).ConvertToEntity();
                context.Autos.Attach(auto);
                auto.Tagestarif += 10;
                Target.UpdateAuto(Target.GetAuto(1), auto.ConvertToDto());
                context.SaveChanges();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<LocalOptimisticConcurrencyException<Kunde>>), "")]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            Target.UpdateKunde(Target.GetKunde(1), Target.GetKunde(1));
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<LocalOptimisticConcurrencyException<Reservation>>), "")]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            Target.UpdateReservation(Target.GetReservation(1), Target.GetReservation(1));
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            int countBefore = Target.GetKunden().Count;
            Target.DeleteKunde(Target.GetKunde(1));
            Assert.AreEqual(countBefore - 1, Target.GetKunden().Count);
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            int countBefore = Target.GetAutos().Count;
            Target.DeleteAuto(Target.GetAuto(1));
            Assert.AreEqual(countBefore - 1, Target.GetAutos().Count);
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            int countBefore = Target.GetReservationen().Count;
            Target.DeleteReservation(Target.GetReservation(1));
            Assert.AreEqual(countBefore - 1, Target.GetReservationen().Count);
        }
    }
}
