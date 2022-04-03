using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicationRESTApi.Contracts;
using MedicationRESTApi.Models;

namespace MedicationtControllerTest
{
    public class MedicationServiceFake : IMedicationService
    {
        private readonly List<Medication> _medications;

        public MedicationServiceFake()
        {
            _medications = new List<Medication>()
            {
                new Medication() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Name = "Aspirina", 
                    CreationDate = DateTime.UtcNow, Quantity = 2 },
                new Medication() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"), Name = "Voltaren", 
                    CreationDate = DateTime.UtcNow, Quantity = 2 }
            };
        }

        public Medication Add(Medication newMedication)
        {
            _medications.Add(newMedication);
            return newMedication;
        }

        public IEnumerable<Medication> GetAllMedications()
        {
            return _medications;
        }

        public Medication GetById(Guid id)
        {
            return _medications.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            var existing = _medications.First(a => a.Id == id);
            _medications.Remove(existing);
        }
    }
}
