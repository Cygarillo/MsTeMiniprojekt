﻿using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;

namespace AutoReservation.Ui.Factory
{
    public class BusinessLayerCreator : Creator
    {
       

        public override IAutoReservationService CreateInstance()
        {
            return new AutoReservationService();
        }
    }
}
