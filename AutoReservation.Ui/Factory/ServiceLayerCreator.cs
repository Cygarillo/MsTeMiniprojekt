﻿using System.ServiceModel;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Ui.Factory
{
    public class ServiceLayerCreator : Creator
    {
        

        public override IAutoReservationService CreateInstance()
        {
            ChannelFactory<IAutoReservationService> channelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
            return channelFactory.CreateChannel();
        }
    }
}
