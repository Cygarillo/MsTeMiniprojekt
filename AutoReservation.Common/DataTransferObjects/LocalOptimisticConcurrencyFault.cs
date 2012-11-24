using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AutoReservation.BusinessLayer;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class LocalOptimisticConcurrencyFault
    {
        [DataMember]
        public string Message { get; set; }
    }
}
