using System.Data.SqlClient;

namespace AutoReservation.Testing
{
    public static class TestEnvironmentHelper
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=AutoReservation;Integrated Security=True";

        public static void InitializeTestData()
        {
            DeleteAll();
            InsertAutos();
            InsertKunden();
            InsertReservationen();
        }

        private static void InsertKunden()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                // Open the connection.
                myConnection.Open();

                SetAutoIncrementOnTable(myConnection, "Kunde", false);

                myCommand.CommandText = "INSERT INTO Kunde (Id, Nachname, Vorname, Geburtsdatum) VALUES (1, 'Nass', 'Anna', '05/05/1961')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Kunde (Id, Nachname, Vorname, Geburtsdatum) VALUES (2, 'Beil', 'Timo', '09/09/1980')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Kunde (Id, Nachname, Vorname, Geburtsdatum) VALUES (3, 'Pfahl', 'Martha', '07/03/1950')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Kunde (Id, Nachname, Vorname, Geburtsdatum) VALUES (4, 'Zufall', 'Rainer', '11/11/1944')";
                myCommand.ExecuteNonQuery();

                SetAutoIncrementOnTable(myConnection, "Kunde", true);
            }
        }

        private static void InsertAutos()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                // Open the connection.
                myConnection.Open();

                SetAutoIncrementOnTable(myConnection, "Auto", false);

                myCommand.CommandText = "INSERT INTO Auto (Id, Marke, AutoKlasse, Tagestarif, Basistarif) VALUES (1, 'Fiat Punto', 2, 50, 0)";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Auto (Id, Marke, AutoKlasse, Tagestarif, Basistarif) VALUES (2, 'VW Golf', 1, 120, 0)";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Auto (Id, Marke, AutoKlasse, Tagestarif, Basistarif) VALUES (3, 'Audi S6', 0, 180, 50)";
                myCommand.ExecuteNonQuery();

                SetAutoIncrementOnTable(myConnection, "Auto", true);
            }
        }

        private static void InsertReservationen()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                // Open the connection.
                myConnection.Open();

                SetAutoIncrementOnTable(myConnection, "Reservation", false);

                myCommand.CommandText = "INSERT INTO Reservation (Id, AutoId, KundeId, Von, Bis)  VALUES(1, 1, 1, '2020-01-10 00:00:00', '2020-01-20 00:00:00')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Reservation (Id, AutoId, KundeId, Von, Bis)  VALUES(2, 2, 2, '2020-01-10 00:00:00', '2020-01-20 00:00:00')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Reservation (Id, AutoId, KundeId, Von, Bis)  VALUES(3, 3, 3, '2020-01-10 00:00:00', '2020-01-20 00:00:00')";
                myCommand.ExecuteNonQuery();

                SetAutoIncrementOnTable(myConnection, "Reservation", true);
            }
        }

        private static void DeleteAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                // Open the connection.
                myConnection.Open();

                myCommand.CommandText = "DELETE FROM Reservation";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "DELETE FROM Auto";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "DELETE FROM Kunde";
                myCommand.ExecuteNonQuery();
            }
        }

        private static void SetAutoIncrementOnTable(SqlConnection myConnection, string table, bool autoIncrementIsOn)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            if (autoIncrementIsOn)
            {
                myCommand.CommandText = "SET IDENTITY_INSERT " + table + " OFF";
            }
            else
            {
                myCommand.CommandText = "SET IDENTITY_INSERT " + table + " ON";
            }

            myCommand.ExecuteNonQuery();
        }

    }
}
