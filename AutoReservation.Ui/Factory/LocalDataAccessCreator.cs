using System;
using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;

namespace AutoReservation.Ui.Factory
{
    class LocalDataAccessCreator : Creator
    {
        public override IAutoReservationService CreateInstance()
        {
            return new AutoReservationService();
        }
    }
}