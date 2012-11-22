using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        AutoReservationBusinessComponent _businessComponent = new AutoReservationBusinessComponent();

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public AutoDto GetAuto(int id)
        {
            WriteActualMethod();
            return _businessComponent.GetAuto(id).ConvertToDto();
        }

        public KundeDto GetKunde(int id)
        {
            WriteActualMethod();
            return _businessComponent.GetKunde(id).ConvertToDto();
        }

        public ReservationDto GetReservation(int reservationNr)
        {
            WriteActualMethod();
            return _businessComponent.GetReservation(reservationNr).ConvertToDto();
        }

        public List<AutoDto> GetAutos()
        {
            WriteActualMethod();
            return _businessComponent.GetAutos().ConvertToDtos();
        }

        public List<KundeDto> GetKunden()
        {
            WriteActualMethod();
            return _businessComponent.GetKunden().ConvertToDtos();
        }

        public List<ReservationDto> GetReservationen()
        {
            WriteActualMethod();
            return _businessComponent.GetReservationen().ConvertToDtos();
        }

        public void AddAuto(AutoDto auto)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.AddAuto(auto.ConvertToEntity());
            } catch(LocalOptimisticConcurrencyException<Auto> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Auto>>(e);
            }
        }

        public void AddKunde(KundeDto kunde)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.AddKunden(kunde.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Kunde> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Kunde>>(e);
            }
        }

        public void AddReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.AddReservation(reservation.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Reservation>>(e);
            }
        }

        public virtual void UpdateAuto(AutoDto original, AutoDto modified)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.UpdateAuto(original.ConvertToEntity(), modified.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Auto> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Auto>>(e);
            }
        }

        public void UpdateKunde(KundeDto original, KundeDto modified)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.UpdateKunde(original.ConvertToEntity(), modified.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Kunde> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Kunde>>(e);
            }
        }

        public void UpdateReservation(ReservationDto original, ReservationDto modified)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.UpdateReservation(original.ConvertToEntity(), modified.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Reservation>>(e);
            }
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.DeleteAuto(auto.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Reservation>>(e);
            }
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.DeleteKunde(kunde.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Reservation>>(e);
            }
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.DeleteReservation(reservation.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Reservation>>(e);
            }
        }
    }
}