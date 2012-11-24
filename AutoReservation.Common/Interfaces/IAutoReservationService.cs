using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract(Namespace = "http://www.hsr.ch/AutoReservationService")]
    public interface IAutoReservationService
    {
        [OperationContract]
        AutoDto GetAuto(int id);
        [OperationContract]
        KundeDto GetKunde(int id);
        [OperationContract]
        ReservationDto GetReservation(int reservationNr);
        [OperationContract]
        List<AutoDto> GetAutos();
        [OperationContract]
        List<KundeDto> GetKunden();
        [OperationContract]
        List<ReservationDto> GetReservationen();
        [OperationContract]
        void AddAuto(AutoDto auto);
        [OperationContract]
        void AddKunde(KundeDto kunde);
        [OperationContract]
        void AddReservation(ReservationDto reservation);
        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcurrencyFault))]
        void UpdateAuto(AutoDto original, AutoDto modified);
        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcurrencyFault))]
        void UpdateKunde(KundeDto original, KundeDto modified);
        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcurrencyFault))]
        void UpdateReservation(ReservationDto original, ReservationDto modified);
        [OperationContract]
        void DeleteAuto(AutoDto auto);
        [OperationContract]
        void DeleteKunde(KundeDto kunde);
        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
