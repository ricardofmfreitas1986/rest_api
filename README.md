# REST API service for medications

This project implements a REST API Service

1. Get a list of medications
2. Add a Medication
3. Create a new medication
4. Delete a medication

It's used SQLite to save all information about medication.
The project is divided in 3 parts:
- MedicationRESTApi - Implementation of REST API Service
- sqliteDB - Data base (to execute - change the connection string)
- TestProject - test the controller implementation

Future updates:
- Add exception handling
- Add async support
- Add logging
- Add authentication and authorization