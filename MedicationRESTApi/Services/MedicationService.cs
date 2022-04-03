using MedicationRESTApi.Models;
using MedicationRESTApi.Contracts;
using MedicationRESTApi.Context;

namespace MedicationRESTApi.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly PharmacyDBContext _pharmacyDBContext;

        public MedicationService(PharmacyDBContext pharmacyDBContext)
        {
            _pharmacyDBContext = pharmacyDBContext;
        }

        public Medication Add(Medication newMedication)
        {
            var result = _pharmacyDBContext.Medications.Add(newMedication);
            _pharmacyDBContext.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<Medication> GetAllMedications()
        {
            return _pharmacyDBContext.Medications.ToList();
        }

        public Medication GetById(Guid id) => _pharmacyDBContext.Medications.FirstOrDefault(x => x.Id == id);

        public void Remove(Guid id)
        {
            var result = _pharmacyDBContext.Medications.FirstOrDefault(_ => _.Id == id);
            if (result != null)
            {
                _pharmacyDBContext.Medications.Remove(result);
                _pharmacyDBContext.SaveChanges();
            }
        }
    }
}
