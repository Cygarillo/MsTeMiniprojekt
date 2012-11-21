using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoReservation.Common.DataTransferObjects;

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
        void InsertAuto(AutoDto auto);
        [OperationContract]
        void InsertKunde(KundeDto kunde);
        [OperationContract]
        void InsertReservation(ReservationDto reservation);
        [OperationContract]
        void UpdateAuto(AutoDto original, AutoDto modified);
        [OperationContract]
        void UpdateKunde(KundeDto original, KundeDto modified);
        [OperationContract]
        void UpdateReservation(ReservationDto original, ReservationDto modified);
        [OperationContract]
        void RemoveAuto(AutoDto auto);
        [OperationContract]
        void RemoveKunde(KundeDto kunde);
        [OperationContract]
        void RemoveReservation(ReservationDto reservation);
    }
}
