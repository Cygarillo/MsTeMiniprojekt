using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using AutoReservation.Testing;
using AutoReservation.Ui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.Ui.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void AutosLoadTest()
        {
            var model = new AutoViewModel();
            var loadCommand = model.LoadCommand;
            Assert.IsTrue(loadCommand.CanExecute(null));
            loadCommand.Execute(null);
            Assert.AreEqual(3,model.Autos.Count);
        }

        [TestMethod]
        public void KundenLoadTest()
        {
            var model = new KundeViewModel();
            var loadCommand = model.LoadCommand;
            Assert.IsTrue(loadCommand.CanExecute(null));
            loadCommand.Execute(null);
            Assert.AreEqual(4, model.Kunden.Count);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            var model = new ReservationViewModel();
            var loadCommand = model.LoadCommand;
            Assert.IsTrue(loadCommand.CanExecute(null));
            loadCommand.Execute(null);
            Assert.AreEqual(3, model.Autos.Count);
        }
    }
}