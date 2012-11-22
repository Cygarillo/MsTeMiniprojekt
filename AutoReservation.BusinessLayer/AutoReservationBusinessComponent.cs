using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal;
using System.Data.Entity;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {

        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }

        public void AddReservation(Reservation res)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Add(res);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, res);
                }
            }

        }

        public List<Reservation> GetReservationen()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservationen.Include(r => r.Kunde).Include(r => r.Auto).ToList();
            }
        }

        public void UpdateReservation(Reservation original, Reservation modified)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }

            }

        }

        public void DeleteReservation(Reservation res)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Attach(res);
                    context.Reservationen.Remove(res);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, res);
                }

            }

        }

        public List<Auto> GetAutos()
        {
            using (var context = new AutoReservationEntities())
            {
                return (from a in context.Autos select a).ToList();
            }
        }

        public void AddAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Autos.Add(auto);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, auto);
                }

            }
        }
        public void DeleteAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Autos.Attach(auto);
                    context.Autos.Remove(auto);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, auto);
                }

            }
        }

        public void UpdateAuto(Auto original, Auto modified)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Autos.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }

            }
        }


        public List<Kunde> GetKunden()
        {
            using (var context = new AutoReservationEntities())
            {
                return (from k in context.Kunden select k).ToList();

            }
        }
        public void AddKunden(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Add(kunde);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, kunde);
                }

            }
        }
        public void DeleteKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Attach(kunde);
                    context.Kunden.Remove(kunde);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, kunde);
                }

            }
        }
        public void UpdateKunde(Kunde original, Kunde modified)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }

            }
        }


        public Auto GetAuto(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return (from a in context.Autos where a.Id == id select a).ToList().ElementAtOrDefault(0);
            }
        }

        public Kunde GetKunde(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return (from k in context.Kunden where k.Id == id select k).ToList().ElementAtOrDefault(0);
            }
        }

        public Reservation GetReservation(int reservationNr)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservationen.Include(r => r.Kunde).Include(r => r.Auto).FirstOrDefault(r => r.ReservationNr == reservationNr);
            }
        }
    }
}