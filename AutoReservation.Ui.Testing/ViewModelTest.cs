using AutoReservation.TestEnvironment;
using AutoReservation.Ui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

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
            AutoViewModel viewModel = new AutoViewModel();
            var command = viewModel.LoadCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsTrue(viewModel.Autos.Count == 3);
        }

        [TestMethod]
        public void KundenLoadTest()
        {
            KundeViewModel viewModel = new KundeViewModel();
            var command = viewModel.LoadCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.AreEqual(4, viewModel.Kunden.Count);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            ReservationViewModel viewModel = new ReservationViewModel();
            var command = viewModel.LoadCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsTrue(viewModel.Reservations.Count == 3);

        }
    }
}