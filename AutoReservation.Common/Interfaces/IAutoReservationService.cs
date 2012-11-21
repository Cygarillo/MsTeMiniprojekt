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
        [FaultContract(typeof(EntityNotFoundException))]
        AutoDto GetAuto(int id);
        [OperationContract]
        [FaultContract(typeof(EntityNotFoundException))]
        KundeDto GetKunde(int id);
        [OperationContract]
        [FaultContract(typeof(EntityNotFoundException))]
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
        void UpdateAuto(AutoDto original, AutoDto modified);
        [OperationContract]
        void UpdateKunde(KundeDto original, KundeDto modified);
        [OperationContract]
        void UpdateReservation(ReservationDto original, ReservationDto modified);
        [OperationContract]
        void DeleteAuto(AutoDto auto);
        [OperationContract]
        void DeleteKunde(KundeDto kunde);
        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }

    [DataContract]
    public class EntityNotFoundException
    {
        private int _id;
        private string _entityName;

        public EntityNotFoundException(string entityName, int id)
        {
            _entityName = entityName;
            _id = id;
        }

        [DataMember]
        public string Message
        {
            get { return String.Format("Entity with id {0} of Type {1} not Found", _id, _entityName); }
        }
    }
}
